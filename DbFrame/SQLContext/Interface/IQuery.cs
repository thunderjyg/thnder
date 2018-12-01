using System;
using System.Collections.Generic;
namespace DbFrame.SqlContext.Interface
{
    //
    using System.Data;
    using System.Linq.Expressions;
    using DbFrame.Class;

    public interface IQuery
    {

        /***********多表表查询*************/
        IEnumerable<T> ToList<T>();
        DataTable ToTable();
        string ToSQL();
        Dictionary<string, object> GetSqlParameters();
        void AddSqlParameters(string Key, object Value);
    }

    public interface IQuery<T1> : IQuery
    where T1 : BaseEntity<T1>, new()
    {
        IQuery<T1> Select(Expression<Func<T1, object>> Select);

        IQuery<T1> Where(Expression<Func<T1, bool>> Where);

        IQuery<T1> WhereIF(bool IsWhere, Expression<Func<T1, bool>> Where);

        IQuery<T1> OrderBy(Expression<Func<T1, object>> OrderBy);

        IQuery<T1> GroupBy(Expression<Func<T1, object>> GroupBy);

        IQuery<T1> CustomSQL(string SQL, object Param);


    }
    public interface IQuery<T1, T2> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
    {
        IQuery<T1, T2> Select(Expression<Func<T1, T2, object>> Select);

        IQuery<T1, T2> Where(Expression<Func<T1, T2, bool>> Where);

        IQuery<T1, T2> WhereIF(bool IsWhere, Expression<Func<T1, T2, bool>> Where);

        IQuery<T1, T2> OrderBy(Expression<Func<T1, T2, object>> OrderBy);

        IQuery<T1, T2> GroupBy(Expression<Func<T1, T2, object>> GroupBy);

        IQuery<T1, T2> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> InnerJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> LeftJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> LeftOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> RightJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> RightOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> FullJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> FullOuterJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2> CrossJoin(Expression<Func<T1, T2, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
    {
        IQuery<T1, T2, T3> Select(Expression<Func<T1, T2, T3, object>> Select);

        IQuery<T1, T2, T3> Where(Expression<Func<T1, T2, T3, bool>> Where);

        IQuery<T1, T2, T3> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, bool>> Where);

        IQuery<T1, T2, T3> OrderBy(Expression<Func<T1, T2, T3, object>> OrderBy);

        IQuery<T1, T2, T3> GroupBy(Expression<Func<T1, T2, T3, object>> GroupBy);

        IQuery<T1, T2, T3> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> InnerJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> LeftJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> LeftOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> RightJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> RightOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> FullJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> FullOuterJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3> CrossJoin(Expression<Func<T1, T2, T3, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
    {
        IQuery<T1, T2, T3, T4> Select(Expression<Func<T1, T2, T3, T4, object>> Select);

        IQuery<T1, T2, T3, T4> Where(Expression<Func<T1, T2, T3, T4, bool>> Where);

        IQuery<T1, T2, T3, T4> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, bool>> Where);

        IQuery<T1, T2, T3, T4> OrderBy(Expression<Func<T1, T2, T3, T4, object>> OrderBy);

        IQuery<T1, T2, T3, T4> GroupBy(Expression<Func<T1, T2, T3, T4, object>> GroupBy);

        IQuery<T1, T2, T3, T4> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> InnerJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> LeftJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> RightJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> RightOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> FullJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> FullOuterJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4> CrossJoin(Expression<Func<T1, T2, T3, T4, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
    {
        IQuery<T1, T2, T3, T4, T5> Select(Expression<Func<T1, T2, T3, T4, T5, object>> Select);

        IQuery<T1, T2, T3, T4, T5> Where(Expression<Func<T1, T2, T3, T4, T5, bool>> Where);

        IQuery<T1, T2, T3, T4, T5> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, bool>> Where);

        IQuery<T1, T2, T3, T4, T5> OrderBy(Expression<Func<T1, T2, T3, T4, T5, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5> GroupBy(Expression<Func<T1, T2, T3, T4, T5, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> RightJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> FullJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
    {
        IQuery<T1, T2, T3, T4, T5, T6> Select(Expression<Func<T1, T2, T3, T4, T5, T6, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6> Where(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
    {
        IQuery<T1, T2, T3, T4, T5, T6, T7> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8> : IQuery
        where T1 : BaseEntity<T1>, new()
        where T2 : BaseEntity<T2>, new()
        where T3 : BaseEntity<T3>, new()
        where T4 : BaseEntity<T4>, new()
        where T5 : BaseEntity<T5>, new()
        where T6 : BaseEntity<T6>, new()
        where T7 : BaseEntity<T7>, new()
        where T8 : BaseEntity<T8>, new()
    {
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> ON, string JoinTabName);

    }
    public interface IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IQuery
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
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Select(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> Select);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Where(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> WhereIF(bool IsWhere, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> Where);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> OrderBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> OrderBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> GroupBy(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> GroupBy);

        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CustomSQL(string SQL, object Param);

        /// <summary>
        /// 内连接（INNER JOIN）
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> InnerJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> LeftOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> RightOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> FullJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 全外连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> FullOuterJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);
        /// <summary>
        /// 交叉连接
        /// </summary>
        /// <returns></returns>
        IQuery<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> CrossJoin(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> ON, string JoinTabName);

    }

}