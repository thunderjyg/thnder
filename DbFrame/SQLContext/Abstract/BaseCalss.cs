using System;
using System.Text;
namespace DbFrame.SqlContext.Abstract
{
    using System.Linq.Expressions;
    using DbFrame.Ado;
    public class BaseCalss
    {
        protected DbHelper _DbHelper { get; set; }
        public BaseCalss()
        {
            _DbHelper = new DbHelper();
        }

        protected StringBuilder Code = new StringBuilder();

        protected object Eval(Expression _Expression)
        {
            var cast = Expression.Convert(_Expression, typeof(object));
            return Expression.Lambda<Func<object>>(cast).Compile().Invoke();
        }



    }
}
