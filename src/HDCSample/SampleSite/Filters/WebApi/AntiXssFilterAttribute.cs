using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security.AntiXss;
using CodeAperture.HDC2016.SampleSite.Models.Exception;

namespace CodeAperture.HDC2016.SampleSite.Filters.WebApi
{
    public class AntiXssFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// This method will fire before the controller method is executed
        /// </summary>        
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var actionArgumentsKeys = actionContext.ActionArguments.Keys;
            var encoder = new AntiXssEncoder();

            foreach (var key in actionArgumentsKeys)
            {
                var data = actionContext.ActionArguments[key];
                var type = data.GetType();

                if (type == typeof(string))
                {
                    data = AntiXssEncoder.HtmlEncode(data.ToString(), false);
                }

            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }      
    }
}