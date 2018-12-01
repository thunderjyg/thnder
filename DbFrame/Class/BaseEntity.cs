using System;
using System.Linq;
namespace DbFrame.Class
{
    public class BaseEntity<T> : EntityClass where T : BaseEntity<T>, new()
    {
        public BaseEntity()
        {
            //初始化 T 得 FieldInfo 字段信息
            this.SetFieldInfo((li) =>
            {
                //实体初始化 将实体信息静态存入当前 对象中
                var list = ReflexHelper.GetPropertyInfos(typeof(T));
                foreach (var item in list)
                {
                    var _FieldAttribute = (Attribute.GetCustomAttribute(item, typeof(FieldAttribute)) as FieldAttribute);
                    if (_FieldAttribute == null) continue;
                    li.Add(new FieldInfo()
                    {
                        Alias = _FieldAttribute.Alias,
                        FieldName = item.Name,
                        FieldType = item.PropertyType,
                        IsIdentity = _FieldAttribute.IsIdentity,
                        IsIgnore = _FieldAttribute.IsIgnore,
                        IsPrimaryKey = _FieldAttribute.IsPrimaryKey
                    });
                }
            });
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        public override string GetTableName()
        {
            var type = typeof(T);
            var attrs = Attribute.GetCustomAttributes(type, true);
            if (attrs.Length == 0) throw new Exception("实体:" + type.Name + "未描述实体对应表名！");
            var _TableAttribute = attrs.Where(item => item is TableAttribute).FirstOrDefault();
            if (_TableAttribute == null) return string.Empty;
            return (_TableAttribute as TableAttribute).TableName;
        }

        /// <summary>
        /// 获取 主键 字段信息
        /// </summary>
        /// <returns></returns>
        public override FieldInfo GetKey()
        {
            var _FieldInfo = this.GetFieldInfo().Where(w => w.IsPrimaryKey == true).FirstOrDefault();

            var _KeyValue = ReflexHelper.GetPropertyInfos(typeof(T)).Where(w => w.Name == _FieldInfo.FieldName).FirstOrDefault().GetValue(this);
            _FieldInfo.Value = _KeyValue;

            return _FieldInfo;
        }

    }

    /// <summary>
    /// 字段描述
    /// </summary>
    public class FieldInfo
    {
        /// <summary>
        /// 字段描述
        /// </summary>
        public string Alias = string.Empty;

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsPrimaryKey = false;

        /// <summary>
        /// 是否为自增
        /// </summary>
        public bool IsIdentity = false;

        /// <summary>
        /// 是否忽略字段【不对该字段 添加、修改 操作】
        /// </summary>
        public bool IsIgnore = false;

        /// <summary>
        /// 字段类型
        /// </summary>
        public Type FieldType = typeof(Guid);

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName = string.Empty;

        /// <summary>
        /// 字段值
        /// </summary>
        public object Value = null;

    }

}
