using System;
//
using DbFrame.Class;

namespace Models
{
    /// <summary>
    /// 菜单与功能绑定 MenuFunction_ID, MenuFunction_MenuID, MenuFunction_FunctionID, MenuFunction_CreateTime
    /// </summary>
    [Table("Sys_MenuFunction")]
    public class Sys_MenuFunctionM : BaseEntity<Sys_MenuFunctionM>
    {

        [Field("ID", FieldType = typeof(Guid?), IsPrimaryKey = true)]
        public Guid? MenuFunction_ID { get; set; }

        [Field("菜单ID")]
        public Guid? MenuFunction_MenuID { get; set; }

        [Field("功能ID")]
        public Guid? MenuFunction_FunctionID { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? MenuFunction_CreateTime { get; set; }


    }
}
