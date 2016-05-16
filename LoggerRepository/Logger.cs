using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;
using Microsoft.Ajax.Utilities;

namespace Log4Netconfiguration.LoggerRepository
{
    public class Logger : ILogger
    {
        private ILog _logger = log4net.LogManager.GetLogger(typeof(ClassType));
       
        public void LogInfo(string message)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(message);
            }
        }

        public void LogException(Exception ex)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(ex);
            }
        }

        public void LogDebug(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(message);
            }
        }

        public void SetOwner(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }

      
    }
}