using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using log4net;
using Log4Netconfiguration.LoggerRepository;
using Microsoft.Ajax.Utilities;

namespace Log4Netconfiguration.Controllers
{
    public class HomeController : Controller
    {
        #region Private Method
        private readonly ILogger _loggerRepository;
        #endregion


        #region Constructor

        public HomeController()
        {

        }
        public HomeController(ILogger loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }
        #endregion



        public ActionResult Index()
        {
            //ILog log = log4net.LogManager.GetLogger(typeof(ClassType));

            log4net.Config.XmlConfigurator.Configure();
            //log.Debug(" Debug log");
            //log.Error("Error log");

            //log.Info("log Info");
            try
            {
                _loggerRepository.LogDebug("debug Log" + DateTime.UtcNow);
                _loggerRepository.LogInfo("log information" + DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                _loggerRepository.LogException(ex);
                throw;
            }
         
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}