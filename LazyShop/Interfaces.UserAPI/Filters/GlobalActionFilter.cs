using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Text;

namespace Interfaces.UserAPI.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalActionFilter : IActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string logInfo = GetLogMessage(context);
            //Common.Log4NetHelper.Info(logInfo);
        }

        private string GetLogMessage(ActionExecutingContext context)
        {
            StringBuilder sb = new StringBuilder();
            string parameters = JsonConvert.SerializeObject(context.ActionArguments);
            sb.Append("[");
            sb.Append(context.HttpContext.Request.Method);
            sb.Append("]  ");
            sb.Append("/");
            sb.Append(context.RouteData.Values["controller"]);
            sb.Append("/");
            sb.Append(context.RouteData.Values["action"]);
            sb.Append("  ");
            sb.Append(parameters);
            return sb.ToString();
        }
    }
}
