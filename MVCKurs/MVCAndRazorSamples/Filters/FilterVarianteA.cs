using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCAndRazorSamples.Filters
{

    //Filter mit IActionFilter-Interface
    public class ActionFilterExample : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }

    public class AsyncActionFilterExample : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // execute any code before the action executes -> OnActionExecuting
            var result = await next();
            // execute any code after the action executes -> OnActionExecuted
        }
    }
}
