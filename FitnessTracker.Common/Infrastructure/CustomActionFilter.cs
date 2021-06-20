using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FitnessTracker.Common.Infrastructure
{
    public class UnauthorizedCustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.IsInRole("Administrator"))
            {
                context.Result = new BadRequestObjectResult("user is unauthorized");
            }
            base.OnActionExecuting(context);
        }
    }
}
