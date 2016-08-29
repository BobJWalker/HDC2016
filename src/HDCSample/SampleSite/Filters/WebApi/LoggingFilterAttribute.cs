using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using NLog;

namespace CodeAperture.HDC2016.SampleSite.Filters.WebApi
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Runs before the controller action starts processing
        /// </summary>        
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var logger = LogManager.GetLogger("database");
            var messageToLog = $@"{actionContext.Request.Method} Request to URL: {actionContext.Request.RequestUri}
Request Data: {GetRequestParameters(actionContext)}";

            logger.Trace(messageToLog);                        
        }

        /// <summary>
        /// Runs after the controller action finishes processing and is ready to send back a response
        /// </summary>        
        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception == null)
            {
                var response = string.Empty;

                if (actionExecutedContext.Response != null && actionExecutedContext.Response.Content != null)
                {
                    response = await actionExecutedContext.Response.Content.ReadAsStringAsync();
                }

                var messageToLog = $@"{actionExecutedContext.Request.Method} Response from URL: {actionExecutedContext.Request.RequestUri}
Response Code: {(actionExecutedContext.Response != null ? actionExecutedContext.Response.StatusCode : HttpStatusCode.InternalServerError)},
Response Data: {(string.IsNullOrWhiteSpace(response) == false && response.Length > 500 ? response.Substring(0, 500) : response)}";

                var logger = LogManager.GetCurrentClassLogger();
                logger.Trace(messageToLog);
            }

            await base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        private string GetRequestParameters(HttpActionContext actionContext)
        {
            var argumentKeys = actionContext.ActionArguments.Keys;
            var content = new StringBuilder();

            foreach (var key in argumentKeys)
            {
                content.AppendLine(JsonConvert.SerializeObject(actionContext.ActionArguments[key]));
            }

            return content.ToString();
        }
    }
}