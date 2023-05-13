using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UCSC.SWFS.SRV.Utilities.RequestHeader;

namespace UCSC.SWFS.SRV.API.Filters
{
    public class RequestHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            try
            {
                IRequestHeader service = actionContext.HttpContext.RequestServices.GetService<IRequestHeader>();
                if (actionContext.HttpContext.Request.Headers.TryGetValue("user", out var value) && !String.IsNullOrEmpty(value))
                {
                    service.UserId = Convert.ToInt32((string)value);
                }
                else
                {
                    BadRequest(actionContext, "user");
                }
            }
            catch (Exception ex)
            {
                BadRequest(actionContext, "user");
            }


        }
        public void BadRequest(ActionExecutingContext actionContext, string param)
        {
             actionContext.HttpContext.Response.StatusCode = 400;
             actionContext.Result = new BadRequestObjectResult("Invalid " + param);
        }
    }
}
