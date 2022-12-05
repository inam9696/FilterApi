namespace FilterApi.Filters
{
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    namespace FilterTask.Service
    {
        public class ActionFilter : IActionFilter
        {

            private void Log(string methodName, RouteData routeData)
            {

                var actionExecuting = routeData.Values["Action Executing"];
              
                Debug.WriteLine(actionExecuting);
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                var method = context.HttpContext.Request.Method;
                context.HttpContext.Response.Headers.Add("MethodName", method);

                var port = context.HttpContext.Request.Host.Port.ToString();
                context.HttpContext.Response.Headers.Add("PortName", port);
                var host = context.HttpContext.Request.Host.ToString();
                context.HttpContext.Response.Headers.Add("HostName", host);
                var scheme = context.HttpContext.Request.Scheme.ToString();
                context.HttpContext.Response.Headers.Add("schemeName", scheme);
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                Log("OnActionExecuted", context.RouteData);
            }
        }
    }
}
