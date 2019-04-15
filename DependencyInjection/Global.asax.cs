using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DependencyInjection.Infrastructure;

namespace DependencyInjection
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new DefaultDependenceResolver());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
