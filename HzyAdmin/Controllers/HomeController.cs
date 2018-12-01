﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HzyAdmin.Controllers
{
    using Common;
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Login", new { Area = "Admin" });
        }

        /// <summary>
        /// 异常拦截
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;

            var IsAjaxRequest = Tools.IsAjaxRequest;

            //判断是否是自定义异常类型
            if (error is MessageBox)
            {
                if (IsAjaxRequest)
                {
                    return Json(MessageBox.errorModel);
                }

                var errorModel = new ErrorModel(error.Message);
                var sb = new StringBuilder();
                sb.Append("<script src=\"/HzyUI/lib/jquery/jquery-2.1.4.min.js\"></script>");
                sb.Append("<script src=\"/Admin/lib/layer-v3.1.1/layer/layer.js\"></script>");
                sb.Append("<script src=\"/Admin/js/admin.js\"></script>");
                sb.Append("<script type='text/javascript'>");
                var MsgText = errorModel.msg.Trim();
                MsgText = MsgText.Replace("'", "“");
                MsgText = MsgText.Replace("\"", "”");
                sb.Append("$(function(){ admin.alert('" + MsgText + "', '警告'); });");
                sb.Append("</script>");
                return Content(sb.ToString(), "text/html;charset=utf-8;");
            }
            else
            {
                Tools.log.WriteLog(error, HttpContext.Connection.RemoteIpAddress.ToString());//log4net 写入日志到 txt
                var errorModel = new ErrorModel(error);
                if (IsAjaxRequest)
                {
                    return Json(errorModel);
                }
                return View(AppConfig.ErrorPageUrl, errorModel);
                //return View("~/Views/Shared/Error.cshtml", error);
            }

        }


    }
}
