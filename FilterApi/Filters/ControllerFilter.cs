namespace FilterApi.Filters
{
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    namespace FilterTask.Service
    {
        public class ControllerFilter : IActionFilter
        {

            private void Log(string methodName, RouteData routeData)
            {

                var actionExecuting = routeData.Values["Action Executing"];
             
                Debug.WriteLine(actionExecuting);
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
               
                if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
                {
                    var controllerName = controllerDescriptor.ControllerName;

                    context.HttpContext.Response.Headers["Controller-Name"] = controllerName;
                }
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                Log("OnActionExecuted", context.RouteData);
            }
        }
    }
}
