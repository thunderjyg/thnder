﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DbFrame.ExpressionTree.Class
{
    using System.Linq.Expressions;
    using DbFrame.Class;
    public class GroupByParser
    {


        public GroupByParser(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias)
        {
            if (_LambdaExpression.Body is ConstantExpression && _LambdaExpression.Body.Type == typeof(string))//如果是字符串
            {
                var body = (_LambdaExpression.Body as ConstantExpression);
                var values = body.Value.ToStr();

                if (string.IsNullOrEmpty(values)) throw new ArgumentNullException(" GROUP BY 参数不能为空字符串或者Null ");

                Code.Append(" GROUP BY " + values);
            }
            else if (_LambdaExpression.Body is NewExpression)//如果是匿名对象
            {
                var body = (_LambdaExpression.Body as NewExpression);
                var values = body.Arguments;
                var member = body.Members;
                Code.Append(" GROUP BY ");
                var column = new List<string>();
                var list_member = member.ToList();
                foreach (MemberExpression item in values)
                {
                    var it = item as MemberExpression;
                    column.Add((it.Expression as ParameterExpression).Name + "." + it.Member.Name);
                }
                Code.Append(string.Join(",", column));
            }
        }









    }
}
