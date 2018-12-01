using System;
using System.Collections.Generic;
using System.Text;
namespace DbFrame.SqlContext
{
    //
    using System.Linq.Expressions;
    using DbFrame.Class;
    using ExpressionTree;

    public class DeleteContext : Abstract.AbstractDelete
    {
        public DeleteContext()
        { }


        public override bool Delete<T>(Expression<Func<T, bool>> Where)
        {
            return Execute<T>(Where);
        }

        public override bool Delete<T>(Expression<Func<T, bool>> Where, List<SQL> li)
        {
            return Execute<T>(Where, li);
        }

        public override bool DeleteById<T>(object Id)
        {
            return ExecuteById<T>(Id);
        }

        public override bool DeleteById<T>(object Id, List<SQL> li)
        {
            return ExecuteById<T>(Id, li);
        }

        public override bool Delete<T>(string WhereStr, object Param)
        {
            Code = new StringBuilder();
            var Model = ReflexHelper.CreateInstance<T>();
            var SqlPar = new Dictionary<string, object>();
            if (Param != null) SqlPar = Param.ToDictionary();
            this.Code.Append("DELETE FROM " + Model.GetTableName() + " WHERE 1=1 " + WhereStr + "; ");

            return _DbHelper.Commit(new List<SQL>() { new SQL(Code.ToString(), SqlPar) });
        }

        public override bool Delete<T>(string WhereStr, object Param, List<SQL> li)
        {
            Code = new StringBuilder();
            var Model = ReflexHelper.CreateInstance<T>();
            var SqlPar = new Dictionary<string, object>();
            if (Param != null) SqlPar = Param.ToDictionary();
            this.Code.Append("DELETE FROM " + Model.GetTableName() + " WHERE 1=1 " + WhereStr + "; ");
            li.Add(new SQL(Code.ToString(), SqlPar));
            return true;
        }

        private bool Execute<T>(Expression<Func<T, bool>> Where, List<SQL> li = null) where T : BaseEntity<T>, new()
        {
            var sql = this.SqlString<T>(Where);
            if (li == null)
            {
                if (!_DbHelper.Commit(new List<SQL>() { sql }))
                    return false;
            }
            else
            {
                li.Add(sql);
            }
            return true;
        }

        private bool ExecuteById<T>(object Id, List<SQL> li = null) where T : BaseEntity<T>, new()
        {
            var sql = this.SqlStringById<T>(Id);
            if (li == null)
            {
                if (!_DbHelper.Commit(new List<SQL>() { sql }))
                    return false;
            }
            else
            {
                li.Add(sql);
            }
            return true;
        }

        private SQL SqlString<T>(Expression<Func<T, bool>> Where) where T : BaseEntity<T>, new()
        {
            return this.Analysis<T>((_ParserArgs, Model) =>
            {
                if (Where != null)
                {
                    _ParserArgs.Builder.Append("AND ");
                    Parser.Where(Where, _ParserArgs);
                }
            });
        }

        private SQL SqlStringById<T>(object Id) where T : BaseEntity<T>, new()
        {
            return this.Analysis<T>((_ParserArgs, Model) =>
            {
                var _Key = Model.GetKey(); if (_Key == null) throw new ArgumentNullException("找不到 实体 中的 主键！");
                _ParserArgs.Builder.Append(" AND " + _Key.FieldName + "=@" + _Key.FieldName + "");
                _ParserArgs.SqlParameters.Add("@" + _Key.FieldName, Id);
            });
        }

        private SQL Analysis<T>(Action<ParserArgs, T> CallBack) where T : BaseEntity<T>, new()
        {
            Code = new StringBuilder();

            var Model = ReflexHelper.CreateInstance<T>();
            string TabName = Model.GetTableName();
            var pa = new ParserArgs();
            pa.TabIsAlias = false;

            CallBack(pa, Model);

            this.Code.Append("DELETE FROM " + TabName + " WHERE 1=1 " + pa.Builder.ToString() + ";");
            return new SQL(Code.ToString(), pa.SqlParameters);
        }












    }
}
