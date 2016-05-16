using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Log4Netconfiguration.App_Start;
using Log4Netconfiguration.Migrations;
using Log4Netconfiguration.Models;

namespace Log4Netconfiguration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            IocConfig.RegisterDependencies();
           // log4net.Config.XmlConfigurator.Configure();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Database.Initialize(false);
            }
        }
    }
}
