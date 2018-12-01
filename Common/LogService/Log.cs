using System;
using System.Collections.Generic;
using System.Text;

namespace Common.LogService
{
    using log4net;
    using log4net.Config;
    using log4net.Repository;
    using System.IO;

    public class Log
    {
        public ILog _ILog;

        public Log()
        {
            if (_ILog == null) _ILog = LogManager.GetLogger(AppConfig.LogNETCoreRepositoryName, "\r\n-------------------------程序异常----------------------------\r\n");
        }

        /// <summary>
        /// 初始化 Log4Net
        /// </summary>
        /// <returns></returns>
        public static ILoggerRepository CreateRepository(ILoggerRepository _ILoggerRepository)
        {
            _ILoggerRepository = LogManager.CreateRepository(AppConfig.LogNETCoreRepositoryName);
            XmlConfigurator.Configure(_ILoggerRepository, new FileInfo("Log4Net/log4net.config"));
            return _ILoggerRepository;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="Text"></param>
        public void WriteLog(string Text)
        {
            _ILog.Error(Text);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="_Exception"></param>
        /// <param name="UserHostAddress"></param>
        /// <param name="CallBack"></param>
        public void WriteLog(Exception _Exception, string UserHostAddress, Action<StringBuilder> CallBack = null)
        {
            var sb = new StringBuilder();
            var _Message = "异常信息: " + _Exception.Message;
            var _Source = "错误源:" + _Exception.Source;
            var _StackTrace = "堆栈信息:" + _Exception.StackTrace;

            sb.Append("\r\n" + UserHostAddress + "\r\n" + _Message + "\r\n" + _Source + "\r\n" + _StackTrace + "\r\n");

            if (CallBack != null)
            {
                CallBack(sb);
            }
            this.WriteLog(sb.ToString());
        }



    }
}
