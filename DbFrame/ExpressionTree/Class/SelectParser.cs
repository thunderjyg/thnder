﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DbFrame.ExpressionTree.Class
{
    using System.Linq.Expressions;
    using DbFrame.Class;
    public class SelectParser
    {


        public SelectParser(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias)
        {

            if (_LambdaExpression.Body is ConstantExpression && _LambdaExpression.Body.Type == typeof(string))//如果是字符串
            {
                var body = (_LambdaExpression.Body as ConstantExpression);

                foreach (var item in _LambdaExpression.Parameters)
                {
                    Alias.Add(item.Name, ReflexHelper.GetTableAttribute(item.Type).TableName);
                }
                var values = body.Value.ToStr();

                Code.Append("SELECT " + (string.IsNullOrEmpty(values) ? "*" : values));

                var ByName = _LambdaExpression.Parameters[0].Name;
                var TabName = Alias[ByName] + " AS " + ByName;
                Code.Append(" FROM " + TabName);

            }
            else if (_LambdaExpression.Body is NewExpression)//如果是匿名对象
            {
                var body = (_LambdaExpression.Body as NewExpression);
                var values = body.Arguments;
                var member = body.Members;
                if (body == null) throw new Exception("语法错误 这里请使用 new {  } 匿名实例化语法！");
                var column = new List<string>();
                foreach (var item in _LambdaExpression.Parameters)
                {
                    Alias.Add(item.Name, ReflexHelper.GetTableAttribute(item.Type).TableName);
                }
                Code.Append("SELECT ");
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
                var ByName = _LambdaExpression.Parameters[0].Name;
                var TabName = Alias[ByName] + " AS " + ByName;
                Code.Append(" FROM " + TabName);
            }

        }




    }
}
