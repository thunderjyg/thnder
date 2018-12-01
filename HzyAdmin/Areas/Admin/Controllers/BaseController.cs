﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HzyAdmin.Areas.Admin.Controllers
{
    //
    using DbFrame;
    using DbFrame.Class;
    using Common;
    using AOP;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.IO;
    using System.Data;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using global::Models;

    [AopActionFilter()]
    [Area(areaName: "Admin")]
    public class BaseController : Controller
    {

        protected DBContext db = new DBContext();
        protected List<SQL> li = new List<SQL>();

        /// <summary>
        /// 主键ID
        /// </summary>
        public string KeyID { get; set; } = string.Empty;

        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuID { get; set; } = string.Empty;

        /// <summary>
        /// 是否执行权限逻辑
        /// </summary>
        public bool IsExecutePowerLogic { get; set; } = true;

        /// <summary>
        /// 打印标题
        /// </summary>
        public string PrintTitle { get; set; } = "无标题";

        /// <summary>
        /// 帐户 信息 对象
        /// </summary>
        protected Sys_AccountM Account = new Sys_AccountM();

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init() { }

        public BaseController()
        {
            Account = Tools.GetSession<Sys_AccountM>("Account");
            this.Init();
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual IActionResult Info()
        {
            return View();
        }

        /// <summary>
        /// Action 执行之后 发生
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (IsExecutePowerLogic && Account != null)
            {
                this.PowerLogic(filterContext);
            }
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 权限逻辑
        /// </summary>
        /// <param name="context"></param>
        private void PowerLogic(ActionExecutedContext context)
        {
            if (!Tools.IsAjaxRequest)
            {
                var _RouteValues = context.ActionDescriptor.RouteValues;
                var _Area = _RouteValues["area"];
                var _Controller = _RouteValues["controller"];
                var _Action = _RouteValues["action"];

                var _func_list = db.FindList<Sys_FunctionM>(null, orderby => new { orderby.Function_Num }).ToList();
                var _power_list = new Dictionary<string, object>();
                //这里得判断一下是否是查找带回调用页面
                string findback = context.HttpContext.Request.Query["findback"];

                if (string.IsNullOrEmpty(findback))
                {
                    //dynamic model = new ExpandoObject();
                    if (string.IsNullOrEmpty(MenuID))
                    {
                        throw new MessageBox("区域(" + _Area + "),控制器(" + _Controller + "):的程序中缺少菜单ID");
                    }

                    var _Menu = db.Find<Sys_MenuM>(w => w.Menu_Num == MenuID);
                    if (!_Menu.Menu_Url.ToStr().StartsWith("/" + _Area + "/" + _Controller + "/"))
                    {
                        throw new MessageBox("区域(" + _Area + "),控制器(" + _Controller + "):的程序中缺少菜单ID与该页面不匹配");
                    }

                    var _role_menu_func_list = db.FindList<Sys_RoleMenuFunctionM>(null, null).ToList();
                    var _menu_func_list = db.FindList<Sys_MenuFunctionM>(null, null);

                    if (!Account.IsSuperManage)
                    {
                        _power_list = new Dictionary<string, object>();
                        _func_list.ForEach(item =>
                        {
                            var ispower = _role_menu_func_list.FindAll(x =>
                                x.RoleMenuFunction_RoleID == Account.RoleID &&
                                x.RoleMenuFunction_MenuID == _Menu.Menu_ID &&
                                x.RoleMenuFunction_FunctionID == item.Function_ID);

                            _power_list.Add(item.Function_ByName, (ispower.Count > 0));

                        });
                    }
                    else
                    {
                        _func_list.ForEach(item =>
                        {
                            _power_list.Add(item.Function_ByName, true);
                            //var ispower = _menu_func_list.FindAll(x => x.uMenuFunction_MenuID == Tools.ToGuid(MenuID) && x.uMenuFunction_FunctionID == item.uFunction_ID);
                            //if (ispower.Count > 0)
                            //    _power_list.Add(item.cFunction_ByName, true);
                            //else
                            //    _power_list.Add(item.cFunction_ByName, false);
                        });
                    }
                }
                else
                {
                    _power_list = new Dictionary<string, object>();
                    _func_list.ForEach(item =>
                    {
                        _power_list.Add(item.Function_ByName, false);
                    });
                    _power_list["Have"] = true;
                    _power_list["Search"] = true;
                }

                this.ViewData["PowerModel"] = _power_list.SerializeObject();
                this.ViewData["thisWindowName"] = "adminIframe-/" + _Area + "/" + _Controller + "/" + _Action;
                this.ViewData["formWindowName"] = "Form_" + _Area + _Controller + _Action;
            }
        }


        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [NonAction]
        public virtual Sys_PagingEntity GetPagingEntity(Hashtable query, int page = 1, int rows = 20)
        {
            return new Sys_PagingEntity();
        }


        /// <summary>
        /// 列表页接口
        /// </summary>
        /// <param name="fc"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult GetDataSource(IFormCollection fc, int page = 1, int rows = 20)
        {
            var query = this.FormCollectionToDictionary(fc);

            var url = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpRequestHeaders)HttpContext.Request.Headers).HeaderReferer.ToStr();
            var dic = this.GetUrlQueryString(url);
            foreach (var item in dic)
            {
                if (!query.ContainsKey(item.Key)) query.Add(item.Key, item.Value);
            }

            var pe = this.GetPagingEntity(query, page, rows);
            return Json(new
            {
                status = 1,
                column = pe.ColModel,
                rows = pe.List,
                page = page,
                total = pe.Counts,
                pageCount = pe.PageCount
            });
        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="fc"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult ExportExcel(IFormCollection fc, int page = 1, int rows = 1000000)
        {
            var query = this.FormCollectionToDictionary(fc);

            foreach (var item in Request.Query.Keys)
            {
                if (!fc.ContainsKey(item.ToString()))
                    query.Add(item.ToString(), Request.Query[item].ToStr());
            }

            var url = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpRequestHeaders)HttpContext.Request.Headers).HeaderReferer.ToStr();
            var dic = this.GetUrlQueryString(url);
            foreach (var item in dic)
            {
                if (!query.ContainsKey(item.Key)) query.Add(item.Key, item.Value);
            }

            var pe = GetPagingEntity(query, page, rows);
            return File(DBToExcel(pe), Tools.GetFileContentType[".xls"].ToStr(), Guid.NewGuid().ToString() + ".xls");
        }

        /// <summary>
        /// 表数据转换为EXCEL
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [NonAction]
        public virtual byte[] DBToExcel(Sys_PagingEntity pe)
        {
            var dt = pe.Table;
            var list = pe.ColModel;
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            //填充表头
            IRow dataRow = sheet.CreateRow(0);
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName.Equals("_ukid"))
                    continue;
                foreach (var item in list)
                {
                    if (column.ColumnName.Equals(item["field"].ToStr()))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(item["title"].ToStr());
                    }
                }
            }

            //填充内容
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Equals("_ukid"))
                        continue;
                    dataRow.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Print(IFormCollection fc)
        {
            TempData["Title"] = PrintTitle;
            var query = this.FormCollectionToDictionary(fc);

            foreach (var item in Request.Query.Keys)
            {
                if (!fc.ContainsKey(item.ToString()))
                    query.Add(item.ToString(), Request.Query[item].ToStr());
            }

            var pe = GetPagingEntity(query, 1, 10000000);
            return View(AppConfig.PrintPageUrl, pe);
        }

        /// <summary>
        /// 将  FormCollection  转换为  Dictionary
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected Hashtable FormCollectionToDictionary(IFormCollection fc)
        {
            var hashtable = new Hashtable();
            if (fc != null)
            {
                fc.Keys.ToList().ForEach(item =>
                {
                    hashtable.Add(item, System.Net.WebUtility.UrlDecode(fc[item]));
                });
            }
            return hashtable;
        }

        /// <summary>
        /// 根据地址字符串获取参数
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        [NonAction]
        public Dictionary<string, object> GetUrlQueryString(string Url)
        {
            var di = new Dictionary<string, object>();
            if (Url.Contains("?"))
            {
                Url = Url.Substring(Url.IndexOf("?") + 1);
                string[] str;
                if (Url.Contains("&"))
                {
                    str = Url.Split('&');
                    foreach (var item in str)
                    {
                        if (item.Contains("="))
                        {
                            di.Add(item.Split('=')[0], (item.Split('=')[1] == "null") ? null : item.Split('=')[1]);
                        }
                    }
                }
                else
                {
                    if (Url.Contains("="))
                    {
                        str = Url.Split('=');
                        di.Add(str[0], str[1]);
                    }
                }
            }
            return di;
        }

        /// <summary>
        /// 处理上传文件
        /// </summary>
        /// <param name="_HttpPostedFileBase"></param>
        /// <param name="Format">文件格式</param>
        /// <param name="Check">执行前 验证回调</param>
        /// <param name="CallBack">如果有回调则保存 否则不保存</param>
        public void HandleUpFile(IFormFile _IFormFile, string[] Format, string _WebRootPath, Action<IFormFile> Check = null, Action<string> CallBack = null)
        {
            if (Check != null) Check(_IFormFile);

            string ExtensionName = Path.GetExtension(_IFormFile.FileName).ToLower().Trim();//获取后缀名

            if (Format != null && !Format.Contains(ExtensionName.ToLower()))
            {
                throw new MessageBox("请上传后缀名为：" + string.Join("、", Format) + " 格式的文件");
            }

            if (CallBack != null)
            {
                if (!Directory.Exists(_WebRootPath + "\\Content\\UpFile\\"))
                    Directory.CreateDirectory(_WebRootPath + "\\Content\\UpFile\\");
                string filePath = "/Content/UpFile/" + Guid.NewGuid() + ExtensionName;
                // 创建新文件
                using (FileStream fs = System.IO.File.Create(_WebRootPath + filePath))
                {
                    _IFormFile.CopyTo(fs);
                    // 清空缓冲区数据
                    fs.Flush();
                }

                CallBack(filePath);
            }
        }

    }
}