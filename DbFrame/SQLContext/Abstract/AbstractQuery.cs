using System;
using System.Collections.Generic;
using System.Linq;
namespace DbFrame.SqlContext.Abstract
{
    using System.Data;
    using System.Linq.Expressions;
    using DbFrame.Class;
    using DbFrame.SqlContext.Interface;
    using DbFrame.ExpressionTree;

    public abstract class AbstractQuery : BaseCalss, IQuery
    {

        //将别名 和表名存起来 别名是 Key
        public Dictionary<string, string> Alias { get; set; }
        protected bool IsAddWhere { get; set; }
        protected ParserArgs _ParserArgs { get; set; }
        public AbstractQuery()
        {
            this.Alias = new Dictionary<string, string>();
            this.IsAddWhere = true;
            this._ParserArgs = new ParserArgs();
        }

        public abstract IEnumerable<T> ToList<T>();
        public abstract DataTable ToTable();
        public abstract string ToSQL();
        public abstract Dictionary<string, object> GetSqlParameters();
        public abstract void AddSqlParameters(string Key, object Value);

        IEnumerable<T> IQuery.ToList<T>()
        {
            return this.ToList<T>();
        }

        DataTable IQuery.ToTable()
        {
            return this.ToTable();
        }

        string IQuery.ToSQL()
        {
            return this.ToSQL();
        }

        Dictionary<string, object> IQuery.GetSqlParameters()
        {
            return GetSqlParameters();
        }

        void IQuery.AddSqlParameters(string Key, object Value)
        {
            this.AddSqlParameters(Key, Value);
        }

        /// <summary>
        /// 开始组装查询语句
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        protected void CodeSelect(LambdaExpression _LambdaExpression)
        {
            Parser.Select(_LambdaExpression, Code, Alias);
        }

        /// <summary>
        /// 链接辅助函数
        /// </summary>
        /// <param name="JoinStr"></param>
        /// <param name="_LambdaExpression"></param>
        /// <param name="JoinTabName"></param>
        protected void CodeJoin(string JoinStr, LambdaExpression _LambdaExpression, string JoinTabName)
        {
            _ParserArgs.Builder.Clear();
            Parser.JoinTable(_LambdaExpression, Code, Alias, _ParserArgs, JoinStr, JoinTabName);
        }

        /// <summary>
        /// 分组辅助函数
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        protected void CodeGroupBy(LambdaExpression _LambdaExpression)
        {
            Parser.GroupBy(_LambdaExpression, Code, Alias);
        }

        /// <summary>
        /// 排序辅助函数
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        protected void CodeOrderBy(LambdaExpression _LambdaExpression)
        {
            Parser.OrderBy(_LambdaExpression, Code, Alias);
        }

        /// <summary>
        /// Where 条件辅助函数
        /// </summary>
        /// <param name="_LambdaExpression"></param>
        protected void CodeWhere(LambdaExpression _LambdaExpression)
        {
            _ParserArgs.Builder.Clear();

            if (IsAddWhere) Code.Append(" WHERE 1=1 ");

            Parser.Where(_LambdaExpression, _ParserArgs);

            Code.Append(" AND " + _ParserArgs.Builder);

            _ParserArgs.Builder.Clear();

            this.IsAddWhere = false;
        }

        /// <summary>
        /// 自定义 Sql
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="Param"></param>
        protected void CodeCustomSQL(string Sql, object Param)
        {
            if (Param != null && Param is object)
            {
                var fields = Param.GetType().GetProperties().ToList();
                foreach (var item in fields)
                {
                    this.AddSqlParameters(item.Name, item.GetValue(Param));
                }
            }
            this.Code.Append(" " + Sql + " ");
        }

    }




    public abstract class AbstractQuery<T1> : AbstractQuery, IQuery<T1>
       where T1 : BaseEntity<T1>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1> Select(Expression<Func<T1, object>> Column);

        public abstract IQuery<T1> Where(Expression<Func<T1, bool>> Where);

        public abstract IQuery<T1> WhereIF(bool IsWhere, Expression<Func<T1, bool>> Where);

        public abstract IQuery<T1> GroupBy(Expression<Func<T1, object>> GroupBy);

        public abstract IQuery<T1> OrderBy(Expression<Func<T1, object>> OrderBy);

        public abstract IQuery<T1> CustomSQL(string SQL, object Param);


        IQuery<T1> IQuery<T1>.Select(Expression<Func<T1, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1> IQuery<T1>.Where(Expression<Func<T1, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1> IQuery<T1>.OrderBy(Expression<Func<T1, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1> IQuery<T1>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2> : AbstractQuery, IQuery<T1, T2>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2> Select(Expression<Func<T1, T2, object>> Column);

        public abstract IQuery<T1, T2> Where(Expression<Func<T1, T2, bool>> Where);

        public abstract IQuery<T1, T2> WhereIF(bool IsWhere, Expression<Func<T1, T2, bool>> Where);

        public abstract IQuery<T1, T2> GroupBy(Expression<Func<T1, T2, object>> GroupBy);

        public abstract IQuery<T1, T2> OrderBy(Expression<Func<T1, T2, object>> OrderBy);

        public abstract IQuery<T1, T2> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2> InnerJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> LeftJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> LeftOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> RightJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> RightOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> FullJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> FullOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2> CrossJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);


        IQuery<T1, T2> IQuery<T1, T2>.Select(Expression<Func<T1, T2, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2> IQuery<T1, T2>.Where(Expression<Func<T1, T2, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2> IQuery<T1, T2>.OrderBy(Expression<Func<T1, T2, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2> IQuery<T1, T2>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2> IQuery<T1, T2>.InnerJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.LeftJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.LeftOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.RightJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.RightOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.FullJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.FullOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2> IQuery<T1, T2>.CrossJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3> : AbstractQuery, IQuery<T1, T2, T3>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3> Select(Expression<Func<T1, T2, T3, object>> Column);

        public abstract IQuery<T1, T2, T3> Where(Expression<Func<T1, T2, T3, bool>> Where);

        public abstract IQuery<T1, T2, T3> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, bool>> Where);

        public abstract IQuery<T1, T2, T3> GroupBy(Expression<Func<T1, T2, T3, object>> GroupBy);

        public abstract IQuery<T1, T2, T3> OrderBy(Expression<Func<T1, T2, T3, object>> OrderBy);

        public abstract IQuery<T1, T2, T3> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3> InnerJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> LeftJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> LeftOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> RightJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> RightOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> FullJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> FullOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3> CrossJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.Select(Expression<Func<T1, T2, T3, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.Where(Expression<Func<T1, T2, T3, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.OrderBy(Expression<Func<T1, T2, T3, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.InnerJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.LeftJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.LeftOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.RightJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.RightOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.FullJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.FullOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3> IQuery<T1, T2, T3>.CrossJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4> : AbstractQuery, IQuery<T1, T2, T3, T4>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4> Select(Expression<Func<T1, T2, T3, T4, object>> Column);

        public abstract IQuery<T1, T2, T3, T4> Where(Expression<Func<T1, T2, T3, T4, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4> GroupBy(Expression<Func<T1, T2, T3, T4, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4> OrderBy(Expression<Func<T1, T2, T3, T4, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4> InnerJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> LeftJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> RightJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> RightOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> FullJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> FullOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4> CrossJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.Select(Expression<Func<T1, T2, T3, T4, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.Where(Expression<Func<T1, T2, T3, T4, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.OrderBy(Expression<Func<T1, T2, T3, T4, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.InnerJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.LeftJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.RightJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.FullJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4> IQuery<T1, T2, T3, T4>.CrossJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5> : AbstractQuery, IQuery<T1, T2, T3, T4, T5>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5> Select(Expression<Func<T1, T2, T3, T4, T5, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5> Where(Expression<Func<T1, T2, T3, T4, T5, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5> GroupBy(Expression<Func<T1, T2, T3, T4, T5, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5> OrderBy(Expression<Func<T1, T2, T3, T4, T5, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> RightJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> FullJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.Select(Expression<Func<T1, T2, T3, T4, T5, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.Where(Expression<Func<T1, T2, T3, T4, T5, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5> IQuery<T1, T2, T3, T4, T5>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6> Select(Expression<Func<T1, T2, T3, T4, T5, T6, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> Where(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6> IQuery<T1, T2, T3, T4, T5, T6>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7> IQuery<T1, T2, T3, T4, T5, T6, T7>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> IQuery<T1, T2, T3, T4, T5, T6, T7, T8>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
        where T10 : BaseEntity<T10>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
        where T10 : BaseEntity<T10>, new()
        where T11 : BaseEntity<T11>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
        where T10 : BaseEntity<T10>, new()
        where T11 : BaseEntity<T11>, new()
        where T12 : BaseEntity<T12>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
        where T10 : BaseEntity<T10>, new()
        where T11 : BaseEntity<T11>, new()
        where T12 : BaseEntity<T12>, new()
        where T13 : BaseEntity<T13>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
        where T10 : BaseEntity<T10>, new()
        where T11 : BaseEntity<T11>, new()
        where T12 : BaseEntity<T12>, new()
        where T13 : BaseEntity<T13>, new()
        where T14 : BaseEntity<T14>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }





    public abstract class AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : AbstractQuery, IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
        where T9 : BaseEntity<T9>, new()
        where T10 : BaseEntity<T10>, new()
        where T11 : BaseEntity<T11>, new()
        where T12 : BaseEntity<T12>, new()
        where T13 : BaseEntity<T13>, new()
        where T14 : BaseEntity<T14>, new()
        where T15 : BaseEntity<T15>, new()
    {
        public AbstractQuery()
        { }

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> Column);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> GroupBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> OrderBy);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CustomSQL(string SQL, object Param);


        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

        public abstract IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> Column)
        {
            return this.Select(Column);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where)
        {
            return this.Where(Where);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> OrderBy)
        {
            return this.OrderBy(OrderBy);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.CustomSQL(string SQL, object Param)
        {
            return this.CustomSQL(SQL, Param);
        }


        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.InnerJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.LeftJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.LeftOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.RightJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.RightOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.FullJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.FullOuterJoin(ON, JoinTabName);
        }

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            return this.CrossJoin(ON, JoinTabName);
        }


        public override IEnumerable<T> ToList<T>()
        {
            return _DbHelper.Query<T>(this.ToSQL(), this.GetSqlParameters());
        }

        public override DataTable ToTable()
        {
            return _DbHelper.QueryDataTable(this.ToSQL(), this.GetSqlParameters());
        }

        public override string ToSQL()
        {
            this.GetSqlParameters();
            return this.Code.ToString();
        }

        public override Dictionary<string, object> GetSqlParameters()
        {
            return this._ParserArgs.SqlParameters;
        }

        public override void AddSqlParameters(string Key, object Value)
        {
            if (this._ParserArgs.SqlParameters.ContainsKey(Key)) throw new Exception("参数话 键" + Key + "已经存在！");
            this._ParserArgs.SqlParameters.Add(Key, Value);
        }






    }














}

