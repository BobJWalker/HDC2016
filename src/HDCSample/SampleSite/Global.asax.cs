using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeAperture.HDC2016.SampleSite.App_Start;
using CodeAperture.HDC2016.SampleSite.Filters;
using CodeAperture.HDC2016.SampleSite.Filters.WebApi;

namespace CodeAperture.HDC2016.SampleSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiRouteConfig.Register);
            MvcFilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiFilterConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
