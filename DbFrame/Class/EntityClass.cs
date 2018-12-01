using System;
using System.Collections.Generic;
namespace DbFrame.Class
{
    public class EntityClass
    {
        protected List<FieldInfo> _FieldInfo = new List<FieldInfo>();

        /// <summary>
        /// 设置字段描述
        /// </summary>
        /// <param name="_Action"></param>
        public void SetFieldInfo(Action<List<FieldInfo>> _Action)
        {
            _Action(this._FieldInfo);
        }

        /// <summary>
        /// 获取字段描述集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FieldInfo> GetFieldInfo()
        {
            return this._FieldInfo;
        }

        public virtual string GetTableName()
        {
            return null;
        }

        public virtual FieldInfo GetKey()
        {
            return null;
        }


    }
}
