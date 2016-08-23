using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CodeAperture.HDC2016.SampleSite.Filters
{
    public class BizLogicFilter : ActionFilterAttribute
    {
        /// <summary>
        /// This method will fire before the controller method is executed
        /// </summary>        
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        /// <summary>
        /// This method will fire after the controller method is completed
        /// </summary>        
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }        
    }
}