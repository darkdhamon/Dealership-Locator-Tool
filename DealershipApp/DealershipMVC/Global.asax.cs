using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DealershipMVC.App_Start;
using DealershipMVC.Infrastructure;

namespace DealershipMVC
{
   public class MvcApplication : HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundle(BundleTable.Bundles);
         ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
      }
   }
}