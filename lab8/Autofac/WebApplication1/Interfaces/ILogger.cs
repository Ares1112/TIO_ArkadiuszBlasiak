using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Interfaces
{
    public interface ILogger
    {
        void Write(string message, LogLevel level);
    }

    public enum LogLevel
    {
        FATAL,
        ERROR,
        WARN,
        INFO,
        DEBUG
    }
}