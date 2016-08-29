using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using CodeAperture.HDC2016.SampleSite.Models.Exception;
using NLog;

namespace CodeAperture.HDC2016.SampleSite.Filters.WebApi
{
    public class ExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {            
            var logger = LogManager.GetCurrentClassLogger();           

            logger.Error(actionExecutedContext.Exception);

            if (actionExecutedContext.Exception is SampleSiteException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception.Message);
            }
            else
            { 
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "We're Sorry.  An unexpected error has occurred.  If this continues please contact Tech Support.");
            }
        }
    }
}