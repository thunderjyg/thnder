using System;
namespace DbFrame.SqlContext
{
    using System.Linq.Expressions;
    using DbFrame.Class;
    using DbFrame.SqlContext.Abstract;
    using DbFrame.SqlContext.Interface;
    public class QueryContext<T1> : AbstractQuery<T1>
       where T1 : BaseEntity<T1>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1> Select(Expression<Func<T1, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1> Where(Expression<Func<T1, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1> WhereIF(bool IsWhere, Expression<Func<T1, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1> GroupBy(Expression<Func<T1, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1> OrderBy(Expression<Func<T1, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }









    }




    public class QueryContext<T1, T2> : AbstractQuery<T1, T2>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2> Select(Expression<Func<T1, T2, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2> Where(Expression<Func<T1, T2, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2> WhereIF(bool IsWhere, Expression<Func<T1, T2, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2> GroupBy(Expression<Func<T1, T2, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2> OrderBy(Expression<Func<T1, T2, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2> InnerJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> LeftJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> LeftOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> RightJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> RightOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> FullJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> FullOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2> CrossJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3> : AbstractQuery<T1, T2, T3>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3> Select(Expression<Func<T1, T2, T3, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3> Where(Expression<Func<T1, T2, T3, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3> GroupBy(Expression<Func<T1, T2, T3, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3> OrderBy(Expression<Func<T1, T2, T3, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3> InnerJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> LeftJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> LeftOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> RightJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> RightOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> FullJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> FullOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3> CrossJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4> : AbstractQuery<T1, T2, T3, T4>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4> Select(Expression<Func<T1, T2, T3, T4, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> Where(Expression<Func<T1, T2, T3, T4, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> GroupBy(Expression<Func<T1, T2, T3, T4, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> OrderBy(Expression<Func<T1, T2, T3, T4, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4> InnerJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> LeftJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> RightJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> RightOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> FullJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> FullOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4> CrossJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5> : AbstractQuery<T1, T2, T3, T4, T5>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5> Select(Expression<Func<T1, T2, T3, T4, T5, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> Where(Expression<Func<T1, T2, T3, T4, T5, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> GroupBy(Expression<Func<T1, T2, T3, T4, T5, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> OrderBy(Expression<Func<T1, T2, T3, T4, T5, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> RightJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> FullJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6> : AbstractQuery<T1, T2, T3, T4, T5, T6>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6> Select(Expression<Func<T1, T2, T3, T4, T5, T6, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> Where(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8>
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
    {
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }




    public class QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : AbstractQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
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
        public QueryContext()
        { }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> Column)
        {
            this.CodeSelect(Column);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where)
        {
            this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where)
        {
            if (IsWhere) this.CodeWhere(Where);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> GroupBy)
        {
            this.CodeGroupBy(GroupBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> OrderBy)
        {
            this.CodeOrderBy(OrderBy);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CustomSQL(string Sql, object Param)
        {
            this.CodeCustomSQL(Sql, Param);
            return this;
        }




        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("INNER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("LEFT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("RIGHT OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("FULL OUTER JOIN", ON, JoinTabName);
            return this;
        }

        public override IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName)
        {
            this.CodeJoin("CROSS JOIN", ON, JoinTabName);
            return this;
        }





    }













}
