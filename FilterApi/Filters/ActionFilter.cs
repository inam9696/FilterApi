namespace FilterApi.Filters
{
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    namespace FilterTask.Service
    {
        public class MethodFilter : IActionFilter
        {

            private void Log(string methodName, RouteData routeData)
            {

                var actionExecuting = routeData.Values["Action Executing"];
                //                                                   
                Debug.WriteLine(actionExecuting);
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
               
                if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
                {
                    var actionName = controllerDescriptor.ActionName;

                    context.HttpContext.Response.Headers["Action-Name"] = actionName;
                }
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                Log("OnActionExecuted", context.RouteData);
            }
        }
    }
}
