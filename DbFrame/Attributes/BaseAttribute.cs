using System;
namespace DbFrame.Class
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class BaseAttribute : Attribute
    {
        public BaseAttribute() { }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

    }
}
