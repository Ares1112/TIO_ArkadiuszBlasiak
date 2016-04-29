using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Interfaces;

namespace WebApplication1
{
    public class Logger : ILogger
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(typeof(Object));

        public void Write(string message, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.FATAL:
                    log.Fatal(message);
                    break;
                case LogLevel.ERROR:
                    log.Error(message);
                    break;
                case LogLevel.WARN:
                    log.Warn(message);
                    break;
                case LogLevel.INFO:
                    log.Info(message);
                    break;
                case LogLevel.DEBUG:
                    log.Debug(message);
                    break;
            }

        }
    }
}