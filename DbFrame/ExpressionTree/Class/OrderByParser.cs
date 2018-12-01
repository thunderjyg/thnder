using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DbFrame.ExpressionTree.Class
{
    using System.Linq.Expressions;
    using DbFrame.Class;
    public class OrderByParser
    {

        public OrderByParser(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias)
        {
            if (_LambdaExpression.Body is ConstantExpression && _LambdaExpression.Body.Type == typeof(string))//如果是字符串
            {
                var body = (_LambdaExpression.Body as ConstantExpression);
                var values = body.Value.ToStr();

                if (string.IsNullOrEmpty(values)) throw new ArgumentNullException(" ORDER BY 参数不能为空字符串或者Null ");

                Code.Append(" ORDER BY " + values);
            }
            else if (_LambdaExpression.Body is NewExpression)//如果是匿名对象
            {
                var body = (_LambdaExpression.Body as NewExpression);
                var values = body.Arguments;
                var member = body.Members;
                Code.Append(" ORDER BY ");
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
                        {
                            if (DisplayName.ToLower() != "asc" && DisplayName.ToLower() != "desc")
                                throw new Exception("ORDER BY 语法错误 请使用 asc 或者 desc 关键字");
                            column.Add((it.Expression as ParameterExpression).Name + "." + it.Member.Name + " " + DisplayName);
                        }
                    }
                    else if (item is ConstantExpression)
                    {
                        var it = item as ConstantExpression;
                        var val = it.Value;
                        //检查是否有别名 ''
                        var DisplayName = list_member[values.IndexOf(item)].Name;
                        if (!string.IsNullOrEmpty(DisplayName))
                        {
                            //判断别名是否 有 SqlString_ 关键字
                            if (DisplayName.StartsWith("SqlString_"))
                            {
                                column.Add(val.ToStr());
                            }
                            else
                            {
                                column.Add(" '" + val + "' " + " AS " + DisplayName);
                            }
                        }
                    }
                }
                Code.Append(string.Join(",", column));
            }
        }

























    }
}
