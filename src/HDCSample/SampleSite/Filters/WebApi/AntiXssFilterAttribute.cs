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

            foreach (var key in actionArgumentsKeys)
            {
                var data = actionContext.ActionArguments[key];
                var type = data.GetType();

                CheckAllStrings(data, type);

                actionContext.ActionArguments[key] = data;
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        private void CheckAllStrings(object data, Type dataType)
        {
            if (dataType == typeof(string))
            {
                var tempData = AntiXssEncoder.HtmlEncode(data.ToString(), false);

                if (string.Equals(tempData, data.ToString(), StringComparison.OrdinalIgnoreCase) == false)
                {
                    throw new SampleSiteException("You attempted to pass in some XSS, no soup for you!");
                }
            }
            else if (dataType.IsClass)
            {
                var properties = dataType.GetProperties();

                foreach (var property in properties)
                {
                    var dataToConvert = property.GetValue(data, null);

                    CheckAllStrings(dataToConvert, property.PropertyType);

                    property.SetValue(data, dataToConvert, null);
                }
            }
        }
    }
}