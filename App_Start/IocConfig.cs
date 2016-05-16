using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Log4Netconfiguration.Controllers;
using Log4Netconfiguration.LoggerRepository;
using Log4Netconfiguration.Models;

namespace Log4Netconfiguration.App_Start
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
             var containerBuilder = new ContainerBuilder();

             //Register all Controller within current assembly
             containerBuilder.RegisterControllers(typeof(HomeController).Assembly);

             //Register DbContext
             containerBuilder.RegisterType<ApplicationDbContext>()
                         .As<DbContext>()
                         .InstancePerDependency();
             /*Register Logger Repository*/
             containerBuilder.RegisterType<Logger>().As<ILogger>();

             var container = containerBuilder.Build();

             //This will set dependency resolver for MVC
             DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

             //This will set dependency resolver for WebAPI
             var resolver = new AutofacWebApiDependencyResolver(container);
             GlobalConfiguration.Configuration.DependencyResolver = resolver;


             return container;
        }
    }
}