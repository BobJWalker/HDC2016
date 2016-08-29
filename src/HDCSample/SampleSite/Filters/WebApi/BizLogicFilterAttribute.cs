using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CodeAperture.HDC2016.SampleSite.Models.Exception;

namespace CodeAperture.HDC2016.SampleSite.Filters.WebApi
{
    public class BizLogicFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// This method will fire before the controller method is executed
        /// </summary>        
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            //Do not use this in production code, it is not truly random
            var random = new Random();

            var result = random.Next(1, 10);

            if (result < 3)
            {
                throw new SampleSiteException("Random Fun!");
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }      
    }
}