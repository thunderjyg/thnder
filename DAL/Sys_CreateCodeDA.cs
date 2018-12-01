﻿using System;
using System.Collections.Generic;
using System.Text;
//
using Common;
using DbFrame;
using DbFrame.Class;
using Models;
using DAL.Class;
using System.Collections;

namespace DAL
{
    using System.Linq;

    public class Sys_CreateCodeDA : BaseDAL
    {

        /// <summary>
        /// 获取数据库中的所有表和字段
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetDatabaseAllTable()
        {
            string sql = @"select TABLE_NAME+' [表]' name,TABLE_NAME id,null pId from INFORMATION_SCHEMA.TABLES
union all
select case when CHARACTER_MAXIMUM_LENGTH is null then COLUMN_NAME+' [字段类型:'+DATA_TYPE+']'
when CHARACTER_MAXIMUM_LENGTH is not null then COLUMN_NAME+' [字段类型:'+DATA_TYPE+'('+CONVERT(varchar(10),CHARACTER_MAXIMUM_LENGTH)+')]' end
 name,TABLE_NAME+'$~'+COLUMN_NAME id,TABLE_NAME from INFORMATION_SCHEMA.COLUMNS";
            return db.FindList<Dictionary<string, object>>(sql, null).ToList();
        }

        /// <summary>
        /// 根据表获取列
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetColByTable(string table)
        {
            string sql = @"select a.COLUMN_NAME colname,case when a.COLUMN_NAME=b.COLUMN_NAME then '主键' end iskey,a.DATA_TYPE type from INFORMATION_SCHEMA.COLUMNS a 
left join INFORMATION_SCHEMA.KEY_COLUMN_USAGE b on a.TABLE_NAME=b.TABLE_NAME where a.TABLE_NAME='" + table + "' ";
            return db.FindList<Dictionary<string, object>>(sql, null).ToList();
        }

        /// <summary>
        /// 获取所有的表
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetAllTable()
        {
            string sql = @"SELECT * FROM INFORMATION_SCHEMA.TABLES";
            return db.FindList<Dictionary<string, object>>(sql, null).ToList();
        }




    }
}
