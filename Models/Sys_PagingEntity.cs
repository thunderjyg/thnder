﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    using System.Data;

    public class Sys_PagingEntity
    {
        /// <summary>
        /// JqGird  ColModel 页面表头
        /// </summary>
        public List<Dictionary<string, object>> ColModel { get; set; }

        /// <summary>
        /// 存放列 和 中文名称
        /// </summary>
        public List<Dictionary<string, string>> ColNames { get; set; }

        /// <summary>
        /// DataTable
        /// </summary>
        public DataTable Table { get; set; }

        /// <summary>
        /// list 列表
        /// </summary>
        public List<Dictionary<string, object>> List { get; set; }

        /// <summary>
        /// 分页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Counts { get; set; }

        public Sys_PagingEntity()
        {
            this.ColModel = new List<Dictionary<string, object>>();
            this.ColNames = new List<Dictionary<string, string>>();
            this.Table = new DataTable();
            this.List = new List<Dictionary<string, object>>();
            this.PageCount = 30;
            this.Counts = 0;
        }


    }
}
