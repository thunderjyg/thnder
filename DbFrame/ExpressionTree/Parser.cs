﻿using System.Collections.Generic;
using System.Text;
namespace DbFrame.ExpressionTree
{
    using System.Linq.Expressions;
    using DbFrame.Class;

    public static class Parser
    {
        public static void Where(Expression _Expression, ParserArgs _ParserArgs)
        {
            new ExpressionParser().Where(_Expression, _ParserArgs);
        }

        public static void Select(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias)
        {
            new ExpressionParser().Select(_LambdaExpression, Code, Alias);
        }

        public static void JoinTable(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias, ParserArgs _ParserArgs, string JoinStr, string JoinTabName)
        {
            new ExpressionParser().JoinTable(_LambdaExpression, Code, Alias, _ParserArgs, JoinStr, JoinTabName);
        }

        public static void OrderBy(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias)
        {
            new ExpressionParser().OrderBy(_LambdaExpression, Code, Alias);
        }

        public static void GroupBy(LambdaExpression _LambdaExpression, StringBuilder Code, Dictionary<string, string> Alias)
        {
            new ExpressionParser().GroupBy(_LambdaExpression, Code, Alias);
        }

    }
}
