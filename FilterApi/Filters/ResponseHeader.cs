using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FilterApi.Filters
{
    public class ResponseHeader : ActionFilterAttribute , IActionFilter
    {
        //private void Log(string methodName, RouteData routeData)
        //{

        //    var actionExecuting = routeData.Values["Action Executing"];                                                       
        //    Debug.WriteLine(actionExecuting);
        //}
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    //Log("OnActionExecuted", context.RouteData);
        //    //if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
        //    //{
        //    //    var methodName = controllerDescriptor.MethodInfo;

        //    //    context.HttpContext.Response.Headers["Mehtod-Name"] = methodName.Name;
        //    //}
        //    //var port = context.HttpContext.Request.Host.Port.ToString();
        //    //context.HttpContext.Response.Headers.Add("PortName", port);
        //    //var host = context.HttpContext.Request.Host.ToString();
        //    //context.HttpContext.Response.Headers.Add("HostName", host);
        //    //var scheme = context.HttpContext.Request.Scheme.ToString();
        //    //context.HttpContext.Response.Headers.Add("schemeName", scheme);
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    Log("OnActionExecuted", context.RouteData);
        //}
    }
}
