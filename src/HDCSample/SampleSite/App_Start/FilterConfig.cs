using System.Web.Mvc;
using CodeAperture.HDC2016.SampleSite.Filters;

namespace CodeAperture.HDC2016.SampleSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());            
        }
    }
}
