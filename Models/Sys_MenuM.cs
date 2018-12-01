using System;
//
using DbFrame.Class;

namespace Models
{
    /// <summary>
    /// 菜单 Menu_ID, Menu_Num, Menu_Name, Menu_Url, Menu_Icon, Menu_ParentID, Menu_CreateTime
    /// </summary>
    [Table("Sys_Menu")]
    public class Sys_MenuM : BaseEntity<Sys_MenuM>
    {

        [Field("ID", IsPrimaryKey = true)]
        public Guid Menu_ID { get; set; }

        [Field("编号")]
        public string Menu_Num { get; set; }

        [Field("菜单名称")]
        public string Menu_Name { get; set; }

        [Field("地址")]
        public string Menu_Url { get; set; }

        [Field("菜单图标")]
        public string Menu_Icon { get; set; }

        [Field("父级ID")]
        public Guid? Menu_ParentID { get; set; }

        [Field("创建时间", IsIgnore = true)]
        public DateTime? Menu_CreateTime { get; set; }

    }
}
