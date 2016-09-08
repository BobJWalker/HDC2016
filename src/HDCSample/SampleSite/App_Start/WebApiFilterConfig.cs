using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CodeAperture.HDC2016.SampleSite.Filters;
using CodeAperture.HDC2016.SampleSite.Filters.WebApi;

namespace CodeAperture.HDC2016.SampleSite.App_Start
{
    public class WebApiFilterConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            //Global Error Handling
            //configuration.Filters.Add(new ExceptionFilterAttribute());

            //Custom Business Logic Filter
            //configuration.Filters.Add(new AntiXssFilterAttribute());

            //Logging Filter
            //configuration.Filters.Add(new LoggingFilterAttribute());
        }
    }
}