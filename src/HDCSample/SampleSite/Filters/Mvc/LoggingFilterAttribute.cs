using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Newtonsoft.Json;
using NLog;

namespace CodeAperture.HDC2016.SampleSite.Filters.Mvc
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var messageToLog = $@"{filterContext.HttpContext.Request.HttpMethod} Request to URL: {filterContext.HttpContext.Request.Url}
Request Data: {GetRequestParameters(filterContext)}";

            logger.Trace(messageToLog);

            base.OnResultExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        private string GetRequestParameters(ResultExecutingContext filterContext)
        {
            var argumentKeys = filterContext.HttpContext.Request.Params.Keys;
            var content = new StringBuilder();

            foreach (var key in argumentKeys)
            {                
                content.AppendLine(JsonConvert.SerializeObject(filterContext.HttpContext.Request.Params.Get(key.ToString())));
            }

            return content.ToString();
        }
    }
}