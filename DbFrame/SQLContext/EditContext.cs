using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbFrame.SqlContext
{
    //
    using System.Linq.Expressions;
    using DbFrame.Class;
    using ExpressionTree;

    public class EditContext : Abstract.AbstractEdit
    {
        public EditContext()
        { }

        public override bool Edit<T>(T Set, Expression<Func<T, bool>> Where)
        {
            var list = new List<MemberBinding>();
            var fileds = ReflexHelper.GetPropertyInfos(typeof(T));//.Where(w => w.Name != Set.GetKey().FieldName);
            foreach (var item in fileds)
            {
                //检测有无忽略字段
                if (Set.GetFieldInfo().Where(w => w.IsIgnore == true && w.FieldName == item.Name).FirstOrDefault() != null) continue;
                list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(Set), item.PropertyType)));
            }

            return Execute<T>(Expression.MemberInit(Expression.New(typeof(T)), list), Where);
        }

        public override bool Edit<T>(Expression<Func<T>> Set, Expression<Func<T, bool>> Where)
        {
            return Execute<T>(Set.Body as MemberInitExpression, Where);
        }

        public override bool Edit<T>(T Set, Expression<Func<T, bool>> Where, List<SQL> li)
        {
            var list = new List<MemberBinding>();
            var fileds = ReflexHelper.GetPropertyInfos(typeof(T));//.Where(w => w.Name != Set.GetKey().FieldName);
            foreach (var item in fileds)
            {
                //检测有无忽略字段
                if (Set.GetFieldInfo().Where(w => w.IsIgnore == true && w.FieldName == item.Name).FirstOrDefault() != null) continue;
                list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(Set), item.PropertyType)));
            }

            return Execute<T>(Expression.MemberInit(Expression.New(typeof(T)), list), Where, li);
        }

        public override bool Edit<T>(Expression<Func<T>> Set, Expression<Func<T, bool>> Where, List<SQL> li)
        {
            return Execute<T>(Set.Body as MemberInitExpression, Where, li);
        }



        public override bool EditById<T>(T Set)
        {
            var list = new List<MemberBinding>();
            var fileds = ReflexHelper.GetPropertyInfos(typeof(T));//.Where(w => w.Name != Set.GetKey().FieldName);
            foreach (var item in fileds)
            {
                //检测有无忽略字段
                if (Set.GetFieldInfo().Where(w => w.IsIgnore == true && w.FieldName == item.Name).FirstOrDefault() != null) continue;
                list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(Set), item.PropertyType)));
            }

            return ExecuteById<T>(Expression.MemberInit(Expression.New(typeof(T)), list));
        }

        public override bool EditById<T>(Expression<Func<T>> Set)
        {
            return ExecuteById<T>((Set.Body as MemberInitExpression));
        }

        public override bool EditById<T>(T Set, List<SQL> li)
        {
            var list = new List<MemberBinding>();
            var fileds = ReflexHelper.GetPropertyInfos(typeof(T));//.Where(w => w.Name != Set.GetKey().FieldName);
            foreach (var item in fileds)
            {
                //检测有无忽略字段
                if (Set.GetFieldInfo().Where(w => w.IsIgnore == true && w.FieldName == item.Name).FirstOrDefault() != null) continue;
                list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(Set), item.PropertyType)));
            }

            return ExecuteById<T>(Expression.MemberInit(Expression.New(typeof(T)), list), li);
        }

        public override bool EditById<T>(Expression<Func<T>> Set, List<SQL> li)
        {
            return ExecuteById<T>(Set.Body as MemberInitExpression, li);
        }


        public override bool Edit<T>(string SetStr, string WhereStr, object Param)
        {
            Code = new StringBuilder();
            var Model = ReflexHelper.CreateInstance<T>();
            var SqlStr = new Dictionary<string, object>();
            if (Param != null) SqlStr = Param.ToDictionary();
            Code.Append("UPDATE " + Model.GetTableName() + " SET " + SetStr + " WHERE 1=1 " + WhereStr);
            return _DbHelper.Commit(new List<SQL>() { new SQL(Code.ToString(), SqlStr) });
        }

        public override bool Edit<T>(string SetStr, string WhereStr, object Param, List<SQL> li)
        {
            Code = new StringBuilder();
            var Model = ReflexHelper.CreateInstance<T>();
            var SqlStr = new Dictionary<string, object>();
            if (Param != null) SqlStr = Param.ToDictionary();
            Code.Append("UPDATE " + Model.GetTableName() + " SET " + SetStr + " WHERE 1=1 " + WhereStr);
            li.Add(new SQL(Code.ToString(), SqlStr));
            return true;
        }






        private bool Execute<T>(MemberInitExpression Set, Expression<Func<T, bool>> Where, List<SQL> li = null)
            where T : BaseEntity<T>, new()
        {
            var sql = this.SqlString(Set, Where);
            if (li == null)
            {
                if (!_DbHelper.Commit(new List<SQL>() { sql })) return false;
            }
            else
            {
                li.Add(sql);
            }
            return true;
        }

        private bool ExecuteById<T>(MemberInitExpression Set, List<SQL> li = null)
            where T : BaseEntity<T>, new()
        {
            var sql = this.SqlStringById<T>(Set);
            if (li == null)
            {
                if (!_DbHelper.Commit(new List<SQL>() { sql })) return false;
            }
            else
            {
                li.Add(sql);
            }
            return true;
        }

        private SQL Analysis<T>(MemberInitExpression Set, Action<ParserArgs, T> CallBack)
            where T : BaseEntity<T>, new()
        {
            Code = new StringBuilder();

            var Model = ReflexHelper.CreateInstance<T>();
            string TabName = Model.GetTableName();
            var set = new List<string>();

            Code.Append("UPDATE " + TabName + " SET ");

            //获取 Where 语句
            var pa = new ParserArgs();
            pa.TabIsAlias = false;

            CallBack(pa, Model);

            var _Where = pa.Builder.ToStr();

            foreach (MemberAssignment item in Set.Bindings)
            {
                //检测有无忽略字段
                if (Model.GetFieldInfo().Where(w => w.IsIgnore == true && w.FieldName == item.Member.Name).FirstOrDefault() != null ||
                    item.Member.Name == Model.GetKey().FieldName)
                    continue;
                var value = this.Eval(item.Expression);
                var name = item.Member.Name;
                var len = pa.SqlParameters.Count;

                set.Add(name + "=@" + name + "_" + len);
                pa.SqlParameters.Add(name + "_" + len, value);
            }

            Code.Append(string.Join(",", set) + " WHERE 1=1 " + _Where + ";");

            return new SQL(Code.ToString(), pa.SqlParameters);
        }

        private SQL SqlString<T>(MemberInitExpression Set, Expression<Func<T, bool>> Where)
            where T : BaseEntity<T>, new()
        {
            return Analysis<T>(Set, (_ParserArgs, Model) =>
            {
                if (Where != null)
                {
                    _ParserArgs.Builder.Append("AND ");
                    Parser.Where(Where, _ParserArgs);
                }
            });
        }

        private SQL SqlStringById<T>(MemberInitExpression Set)
            where T : BaseEntity<T>, new()
        {
            return Analysis<T>(Set, (_ParserArgs, Model) =>
            {
                var _Key = Model.GetKey(); if (_Key == null) throw new ArgumentNullException("找不到 实体 中的 主键！");
                var IdValue = this.Eval((Set.Bindings.Where(w => w.Member.Name == _Key.FieldName).FirstOrDefault() as MemberAssignment).Expression);
                _ParserArgs.Builder.Append(" AND " + _Key.FieldName + "=@" + _Key.FieldName + "");
                _ParserArgs.SqlParameters.Add("@" + _Key.FieldName, IdValue);
            });
        }




    }
}
