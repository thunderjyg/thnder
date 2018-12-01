using System;
using System.Collections.Generic;
namespace DbFrame.SqlContext
{
    using System.Data;
    using System.Linq.Expressions;
    using DbFrame.Class;
    using DbFrame.SqlContext.Abstract;
    using DbFrame.SqlContext.Interface;

    public class FindContext : AbstractFind
    {

        public FindContext() { }

        public IQuery<T1> Query<T1>(Expression<Func<T1, object>> Select)
            where T1 : BaseEntity<T1>, new()
        {
            return new QueryContext<T1>().Select(Select);
        }

        public IQuery<T1, T2> Query<T1, T2>(Expression<Func<T1, T2, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
        {
            return new QueryContext<T1, T2>().Select(Select);
        }

        public IQuery<T1, T2, T3> Query<T1, T2, T3>(Expression<Func<T1, T2, T3, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
            where T3 : BaseEntity<T3>, new()
        {
            return new QueryContext<T1, T2, T3>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4> Query<T1, T2, T3, T4>(Expression<Func<T1, T2, T3, T4, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
            where T3 : BaseEntity<T3>, new()
            where T4 : BaseEntity<T4>, new()
        {
            return new QueryContext<T1, T2, T3, T4>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5> Query<T1, T2, T3, T4, T5>(Expression<Func<T1, T2, T3, T4, T5, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
            where T3 : BaseEntity<T3>, new()
            where T4 : BaseEntity<T4>, new()
            where T5 : BaseEntity<T5>, new()
        {
            return new QueryContext<T1, T2, T3, T4, T5>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6> Query<T1, T2, T3, T4, T5, T6>(Expression<Func<T1, T2, T3, T4, T5, T6, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
            where T3 : BaseEntity<T3>, new()
            where T4 : BaseEntity<T4>, new()
            where T5 : BaseEntity<T5>, new()
            where T6 : BaseEntity<T6>, new()
        {
            return new QueryContext<T1, T2, T3, T4, T5, T6>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7> Query<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
            where T3 : BaseEntity<T3>, new()
            where T4 : BaseEntity<T4>, new()
            where T5 : BaseEntity<T5>, new()
            where T6 : BaseEntity<T6>, new()
            where T7 : BaseEntity<T7>, new()
        {
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Query<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> Select)
            where T1 : BaseEntity<T1>, new()
            where T2 : BaseEntity<T2>, new()
            where T3 : BaseEntity<T3>, new()
            where T4 : BaseEntity<T4>, new()
            where T5 : BaseEntity<T5>, new()
            where T6 : BaseEntity<T6>, new()
            where T7 : BaseEntity<T7>, new()
            where T8 : BaseEntity<T8>, new()
        {
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>().Select(Select);
        }

        public IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> Select)
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
            return new QueryContext<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>().Select(Select);
        }


        /************************* 基础 函数***************************/
        public override T FindSingle<T>(string SqlStr, object Param)
        {
            return this._DbHelper.QuerySingleOrDefault<T>(SqlStr, Param);
        }

        public override DataTable FindTable(string SqlStr, object Param)
        {
            return this._DbHelper.QueryDataTable(SqlStr, Param);
        }

        public override T Find<T>(string SqlStr, object Param)
        {
            var _Model = this._DbHelper.QueryFirstOrDefault<T>(SqlStr, Param);
            if (_Model == null)
                return ReflexHelper.CreateInstance<T>();
            return _Model;
        }

        public override IEnumerable<T> FindList<T>(string SqlStr, object Param)
        {
            return this._DbHelper.Query<T>(SqlStr, Param);
        }

        public override Paging FindPaging(string Sql, int Page, int PageSize, object Param)
        {
            return this._DbHelper.QueryPaging(Sql, Page, PageSize, Param);
        }

        public override int FindMaxNumber(string TabName, string FieldNum, string Where, object Param)
        {
            var SqlStr = this._DbHelper.FindMaxNumber(TabName, FieldNum, Where, Param);
            return this.FindSingle<int>(SqlStr, Param);
        }

        ///************************* 表达式树 函数***************************/
        public override DataTable FindTable<T>(Expression<Func<T, bool>> Where, Expression<Func<T, object>> OrderBy)
        {
            var _SQL = this.GetSqlStr(null, Where, OrderBy);
            return this._DbHelper.QueryDataTable(_SQL.Sql_Parameter, _SQL.Parameter);
        }

        public override T Find<T>(Expression<Func<T, bool>> Where)
        {
            var _SQL = this.GetSqlStr(null, Where, null);
            var _Model = this._DbHelper.QueryFirstOrDefault<T>(_SQL.Sql_Parameter, _SQL.Parameter);
            if (_Model == null)
                return ReflexHelper.CreateInstance<T>();
            return _Model;
        }

        public override T FindById<T>(object Id)
        {
            var _SQL = this.GetSqlStrById<T>(null, Id, null);
            var _Model = this._DbHelper.QueryFirstOrDefault<T>(_SQL.Sql_Parameter, _SQL.Parameter);
            if (_Model == null)
                return ReflexHelper.CreateInstance<T>();
            return _Model;
        }

        public override IEnumerable<T> FindList<T>(Expression<Func<T, bool>> Where, Expression<Func<T, object>> OrderBy)
        {
            var _SQL = this.GetSqlStr(null, Where, OrderBy);
            return this._DbHelper.Query<T>(_SQL.Sql_Parameter, _SQL.Parameter);
        }

        ///************************* 表达式树 函数 自定义 Select ***************************/
        public override DataTable FindTable<T>(Expression<Func<T, object>> Select, Expression<Func<T, bool>> Where, Expression<Func<T, object>> OrderBy)
        {
            var _SQL = this.GetSqlStr(Select, Where, OrderBy);
            return this._DbHelper.QueryDataTable(_SQL.Sql_Parameter, _SQL.Parameter);
        }

        public override T FindSingle<T>(Expression<Func<T, object>> Select, Expression<Func<T, bool>> Where)
        {
            var _SQL = this.GetSqlStr(Select, Where, null);
            return this._DbHelper.QuerySingleOrDefault<T>(_SQL.Sql_Parameter, _SQL.Parameter);
        }

        public override T FindSingle<T>(string Select, Expression<Func<T, bool>> Where)
        {
            var _SQL = this.GetSqlStr(Select, Where);
            return this._DbHelper.QuerySingleOrDefault<T>(_SQL.Sql_Parameter, _SQL.Parameter);
        }

        public override T Find<T>(Expression<Func<T, object>> Select, Expression<Func<T, bool>> Where)
        {
            var _SQL = this.GetSqlStr(Select, Where, null);
            var _Model = this._DbHelper.QueryFirstOrDefault<T>(_SQL.Sql_Parameter, _SQL.Parameter);
            if (_Model == null)
                return ReflexHelper.CreateInstance<T>();
            return _Model;
        }

        public override T FindById<T>(Expression<Func<T, object>> Select, object Id)
        {
            var _SQL = this.GetSqlStrById(Select, Id, null);
            var _Model = this._DbHelper.QueryFirstOrDefault<T>(_SQL.Sql_Parameter, _SQL.Parameter);
            if (_Model == null)
                return ReflexHelper.CreateInstance<T>();
            return _Model;
        }

        public override IEnumerable<T> FindList<T>(Expression<Func<T, object>> Select, Expression<Func<T, bool>> Where, Expression<Func<T, object>> OrderBy)
        {
            var _SQL = this.GetSqlStr(Select, Where, OrderBy);
            return this._DbHelper.Query<T>(_SQL.Sql_Parameter, _SQL.Parameter);
        }
    }
}
