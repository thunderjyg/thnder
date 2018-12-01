﻿using System;
//
using DbFrame.Class;

namespace Models
{
    /// <summary>
    /// 功能 Function_ID, Function_Num, Function_Name, Function_ByName, Function_CreateTime
    /// </summary>
    [Table("Sys_Function")]
    public class Sys_FunctionM : BaseEntity<Sys_FunctionM>
    {

        [Field("ID", IsPrimaryKey = true)]
        public Guid Function_ID { get; set; }

        [Field("编号")]
        public string Function_Num { get; set; }

        [CRequired(ErrorMessage = "{name}不能为空")]
        [CRepeat(ErrorMessage = "{name}已存在")]
        [Field("功能名称")]
        public string Function_Name { get; set; }

        [CRequired(ErrorMessage = "{name}不能为空")]
        [CRepeat(ErrorMessage = "{name}已存在")]
        [Field("功能英文名")]
        public string Function_ByName { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? Function_CreateTime { get; set; }




    }
}
