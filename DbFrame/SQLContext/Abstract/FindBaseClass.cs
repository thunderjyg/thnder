using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DbFrame.SqlContext.Abstract
{
    using System.Linq.Expressions;
    using DbFrame.Class;
    using DbFrame.ExpressionTree;

    public class FindBaseClass : BaseCalss
    {

        protected SQL GetSqlStr<T>(Expression<Func<T, object>> Select, Expression<Func<T, bool>> Where, Expression<Func<T, object>> OrderBy)
            where T : BaseEntity<T>, new()
        {
            Code = new StringBuilder();
            var Parma = new Dictionary<string, object>();
            var _Model = (T)Activator.CreateInstance(typeof(T));

            //Select

            Code.Append("SELECT ");

            if (Select == null)
                Code.Append("* ");
            else
                this.GetSelect(Select, Code);

            Code.Append(" FROM " + _Model.GetTableName() + " ");

            //Where

            if (Where != null)
            {
                var _ParserArgs = new ParserArgs();

                Code.Append("AS " + Where.Parameters[0].Name + " WHERE 1=1 ");

                Parser.Where(Where, _ParserArgs);
                Code.Append(" AND " + _ParserArgs.Builder);
                foreach (var item in _ParserArgs.SqlParameters)
                {
                    Parma.Add(item.Key, item.Value);
                }
            }

            //OrderBy

            if (OrderBy != null) this.GetOrderBy(OrderBy, Code);

            return new SQL(Code.ToString(), Parma);
        }



        protected SQL GetSqlStr<T>(string Select, Expression<Func<T, bool>> Where)
            where T : BaseEntity<T>, new()
        {
            Code = new StringBuilder();
            var Parma = new Dictionary<string, object>();
            var _Model = (T)Activator.CreateInstance(typeof(T));

            //Select

            Code.Append("SELECT ");

            if (string.IsNullOrEmpty(Select))
                Code.Append("* ");
            else
                Code.Append(Select);

            Code.Append(" FROM " + _Model.GetTableName() + " ");

            //Where

            if (Where != null)
            {
                var _ParserArgs = new ParserArgs();

                Code.Append("AS " + Where.Parameters[0].Name + " WHERE 1=1 ");

                Parser.Where(Where, _ParserArgs);
                Code.Append(" AND " + _ParserArgs.Builder);
                foreach (var item in _ParserArgs.SqlParameters)
                {
                    Parma.Add(item.Key, item.Value);
                }
            }

            return new SQL(Code.ToString(), Parma);
        }


        protected SQL GetSqlStrById<T>(Expression<Func<T, object>> Select, object Id, Expression<Func<T, object>> OrderBy)
            where T : BaseEntity<T>, new()
        {
            Code = new StringBuilder();
            var Parma = new Dictionary<string, object>();
            var _Model = (T)Activator.CreateInstance(typeof(T));

            //Select

            Code.Append("SELECT ");

            if (Select == null)
                Code.Append("* ");
            else
                this.GetSelect(Select, Code);

            Code.Append(" FROM " + _Model.GetTableName() + " ");

            //Where

            var _ParserArgs = new ParserArgs();
            Code.Append("WHERE 1=1 ");
            var KeyName = _Model.GetKey().FieldName;
            Code.Append(" AND " + KeyName + "=@" + KeyName);
            Parma.Add(KeyName, Id);

            //OrderBy

            if (OrderBy != null) this.GetOrderBy(OrderBy, Code);

            return new SQL(Code.ToString(), Parma);
        }



















        private void GetSelect(LambdaExpression _LambdaExpression, StringBuilder Code)
        {
            var body = (_LambdaExpression.Body as NewExpression);
            if (body == null) throw new Exception("语法错误 这里请使用 new {  } 匿名实例化语法！");
            var values = body.Arguments;
            var member = body.Members;
            var column = new List<string>();
            var list_member = member.ToList();
            foreach (var item in values)
            {
                if (item is MemberExpression)
                {
                    var it = item as MemberExpression;
                    //检查是否有别名
                    var DisplayName = list_member[values.IndexOf(item)].Name;
                    if (DisplayName == it.Member.Name)
                        column.Add((it.Expression as ParameterExpression).Name + "." + it.Member.Name);
                    else
                        column.Add((it.Expression as ParameterExpression).Name + "." + it.Member.Name + " AS " + DisplayName);
                }
                else if (item is ConstantExpression)
                {
                    var it = item as ConstantExpression;
                    var val = it.Value;
                    //检查是否有别名 ''
                    var DisplayName = list_member[values.IndexOf(item)].Name;
                    if (!string.IsNullOrEmpty(DisplayName))
                        column.Add(" '" + val + "' " + " AS " + DisplayName);
                }
            }
            Code.Append(string.Join(",", column));
        }


        private void GetOrderBy(LambdaExpression _LambdaExpression, StringBuilder Code)
        {
            try
            {
                var body = (_LambdaExpression.Body as NewExpression);
                var values = body.Arguments;
                var member = body.Members;
                Code.Append(" ORDER BY ");
                var column = new List<string>();
                var list_member = member.ToList();
                foreach (MemberExpression item in values)
                {
                    var it = item as MemberExpression;
                    //检查是否有别名
                    var DisplayName = list_member[values.IndexOf(item)].Name;

                    if (DisplayName == it.Member.Name)
                        column.Add(it.Member.Name);
                    else
                    {
                        if (DisplayName.ToLower() != "asc" && DisplayName.ToLower() != "desc")
                            throw new Exception("ORDER BY 语法错误 请使用 asc 或者 desc 关键字");
                        column.Add(it.Member.Name + " " + DisplayName);
                    }

                }
                Code.Append(string.Join(",", column));
            }
            catch (Exception ex)
            {
                throw new Exception("ORDER BY 语法错误 请使用 new{f1,desc=f2} 类似这种语法！" + ex.Message);
            }
        }



















    }
}
