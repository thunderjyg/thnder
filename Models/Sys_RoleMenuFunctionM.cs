using System;
//
using DbFrame.Class;

namespace Models
{
    /// <summary>
    /// 角色菜单功能绑定 RoleMenuFunction_ID, RoleMenuFunction_RoleID, RoleMenuFunction_FunctionID, RoleMenuFunction_MenuID, RoleMenuFunction_CreateTime
    /// </summary>
    [Table("Sys_RoleMenuFunction")]
    public class Sys_RoleMenuFunctionM : BaseEntity<Sys_RoleMenuFunctionM>
    {

        [Field("ID", IsPrimaryKey = true)]
        public Guid RoleMenuFunction_ID { get; set; }

        [Field("角色ID")]
        public Guid? RoleMenuFunction_RoleID { get; set; }

        [Field("功能ID")]
        public Guid? RoleMenuFunction_FunctionID { get; set; }

        [Field("菜单ID")]
        public Guid? RoleMenuFunction_MenuID { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? RoleMenuFunction_CreateTime { get; set; }

    }
}
