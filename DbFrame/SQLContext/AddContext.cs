using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DbFrame.SqlContext
{
    //
    using System.Linq.Expressions;
    using DbFrame.Class;

    public class AddContext : Abstract.AbstractAdd
    {
        public AddContext()
        { }

        public override object Add<T>(T Model)
        {
            var body = ReflexHelper.MemberInit<T>(Model);
            return this.Execute<T>(ref body, Model);
        }

        public override object Add<T>(T Model, List<SQL> li)
        {
            var body = ReflexHelper.MemberInit<T>(Model);
            return this.Execute<T>(ref body, Model, li);
        }

        public override object Add<T>(Expression<Func<T>> Func)
        {
            var body = (Func.Body as MemberInitExpression);
            return this.Execute<T>(ref body, ReflexHelper.CreateInstance<T>());
        }

        public override object Add<T>(Expression<Func<T>> Func, List<SQL> li)
        {
            var body = (Func.Body as MemberInitExpression);
            return this.Execute<T>(ref body, ReflexHelper.CreateInstance<T>(), li);
        }

        public override bool Add<T>(string SqlStr, object Param)
        {
            var Model = ReflexHelper.CreateInstance<T>();
            var SqlPar = new Dictionary<string, object>();
            Code = new StringBuilder();
            Code.Append("INSERT INTO " + Model.GetTableName() + " " + SqlStr);
            if (Param != null) SqlPar = Param.ToDictionary();
            var Sql = new SQL(Code.ToString(), SqlPar);

            return _DbHelper.Commit(new List<SQL>() { Sql });
        }

        public override bool Add<T>(string SqlStr, object Param, List<SQL> li)
        {
            var Model = ReflexHelper.CreateInstance<T>();
            var SqlPar = new Dictionary<string, object>();
            Code = new StringBuilder();
            Code.Append("INSERT INTO " + Model.GetTableName() + " " + SqlStr);
            if (Param != null) SqlPar = Param.ToDictionary();
            var Sql = new SQL(Code.ToString(), SqlPar);
            li.Add(Sql);
            return true;
        }

        public override object AddIdentity<T>(T Model, object NewModel)
        {
            var body = ReflexHelper.MemberInit<T>(Model);
            return this.Execute<T>(ref body, Model, null, NewModel);
        }

        public override bool AddIdentity<T>(T Model, object NewModel, List<SQL> li)
        {
            var body = ReflexHelper.MemberInit<T>(Model);
            return !string.IsNullOrEmpty(this.Execute<T>(ref body, Model, li, NewModel));
        }

        private string Execute<T>(ref MemberInitExpression body, T Model, List<SQL> li = null, object NewModel = null)
            where T : BaseEntity<T>, new()
        {
            var _modelKey = Model.GetKey();
            var Id = this.CreatePrimaryKey<T>(ref body, _modelKey.FieldName, _modelKey.FieldType, _modelKey.IsIdentity).ToStr();

            var Sql = this.Analysis<T>(body, Model, NewModel);

            if (li == null)
            {
                var _Sql = Sql.Sql;
                var _Sql_Parameter = Sql.Sql_Parameter;

                Sql.Sql = Sql.Sql.Replace("/*GetId()*/", "");
                Sql.Sql_Parameter = Sql.Sql_Parameter.Replace("/*GetId()*/", "");

                if (!_DbHelper.Commit(new List<SQL>() { Sql })) Id = string.Empty;

                if (_modelKey.FieldType == typeof(int?) && _modelKey.IsIdentity && Id.StartsWith("ID#"))
                {
                    Id = Id.Replace("ID#", "");
                    _Sql = _Sql.Replace("/*GetId()*/", Id);
                    _Sql_Parameter = _Sql_Parameter.Replace("/*GetId()*/", Id);
                    Id = _DbHelper.ExecuteScalar<int?>(_Sql, _Sql_Parameter).ToStr();
                    return Id;
                }

                return Id;
            }
            else
            {
                Sql.Sql = Sql.Sql.Replace("/*GetId()*/", "");
                Sql.Sql_Parameter = Sql.Sql_Parameter.Replace("/*GetId()*/", "");
            }

            li.Add(Sql);
            return Id;
        }

        private SQL Analysis<T>(MemberInitExpression Body, T Model, object NewModel = null)
            where T : BaseEntity<T>, new()
        {
            Code = new StringBuilder();

            string TabName = Model.GetTableName();
            var _modelKey = Model.GetKey();
            var SqlPar = new Dictionary<string, object>();

            Code.Append("INSERT INTO " + TabName + " ");

            var col = new List<string>();
            var val = new List<string>();

            var _NewModel_Dic = new Dictionary<string, object>();
            if (NewModel != null)
            {
                _NewModel_Dic = NewModel.ToDictionary();
            }

            var _FieldInfo_List = Model.GetFieldInfo();

            foreach (MemberAssignment item in Body.Bindings)
            {

                //检测有无忽略字段
                if (_FieldInfo_List.Where(w => w.IsIgnore == true && w.FieldName == item.Member.Name).FirstOrDefault() != null) continue;
                var name = item.Member.Name;
                var len = SqlPar.Count;

                col.Add(name);
                if (NewModel != null)
                {
                    val.Add(_NewModel_Dic[name].ToStr());
                }
                else
                {
                    val.Add("@" + name + "_" + len);
                    var value = this.Eval(item.Expression);
                    SqlPar.Add(name + "_" + len, value);
                }
            }

            Code.Append(string.Format("({0}) VALUES ({1});/*GetId()*/", string.Join(",", col), string.Join(",", val)));

            return new SQL(Code.ToString(), SqlPar);
        }

        /// <summary>
        /// 创建主键
        /// </summary>
        /// <returns></returns>
        private object CreatePrimaryKey<T>(ref MemberInitExpression body, string FiledName, Type type, bool IsIdentity)
            where T : BaseEntity<T>, new()
        {
            object id;

            if (type == typeof(Guid?) || type == typeof(Guid))
            {
                var list = new List<MemberBinding>();
                var Model = ReflexHelper.CreateInstance<T>();
                //检测 用户是否自己设置了主键
                var member = (body.Bindings.Where(item => item.Member.Name == FiledName).FirstOrDefault() as MemberAssignment);
                if (member == null)
                {
                    id = Guid.NewGuid();
                    var memberinfo = Model.GetType().GetProperty(FiledName);
                    list.Add(Expression.Bind(memberinfo, Expression.Constant(id, typeof(Guid))));
                }
                else
                {
                    var value = this.Eval(member.Expression);
                    if (value.ToGuid() == Guid.Empty)
                        id = Guid.NewGuid();
                    else
                        id = value;
                }

                foreach (MemberAssignment item in body.Bindings)
                {
                    if (item.Member.Name == FiledName)
                        list.Add(Expression.Bind(item.Member, Expression.Constant(id, item.Expression.Type)));
                    else
                        list.Add(Expression.Bind(item.Member, Expression.Constant(this.Eval(item.Expression), item.Expression.Type)));
                }

                body = Expression.MemberInit(Expression.New(typeof(T)), list);
                return id;
            }
            else if ((type == typeof(int?) || (type == typeof(int)) && IsIdentity))
            {
                return _DbHelper.GetLastInsertId();
            }
            else
            {
                return this.Eval(((body.Bindings.Where(item => item.Member.Name == FiledName).FirstOrDefault()) as MemberAssignment).Expression);
            }
        }

    }
}
