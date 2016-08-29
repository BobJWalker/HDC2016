using System.Web.Mvc;
using CodeAperture.HDC2016.SampleSite.Filters.Mvc;

namespace CodeAperture.HDC2016.SampleSite
{
    public class MvcFilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());  
            filters.Add(new LoggingFilterAttribute());          
        }
    }
}
