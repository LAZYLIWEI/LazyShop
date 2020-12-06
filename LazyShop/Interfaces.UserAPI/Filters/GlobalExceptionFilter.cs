using Interfaces.UserAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.UserAPI.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                // 通知前端信息
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(new VResult
                    {
                        Code = ReturnCode.EXCEPTION,
                        Data = context.Exception.ToString(),
                        Msg = "系统开小差了"
                    }),
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "text/json;charset=utf-8"
                };

                string logInfo = GetLogMessage(context);
                //Common.Log4NetHelper.Error(logInfo);
            }

            context.ExceptionHandled = true;
        }


        private string GetLogMessage(ExceptionContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetRouteInfo(context));
            sb.Append(GetExceptionMessage(context));
            return sb.ToString();
        }


        private string GetRouteInfo(ExceptionContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(context.HttpContext.Request.Method);
            sb.Append("]  ");
            sb.Append("/");
            sb.Append(context.RouteData.Values["controller"]);
            sb.Append("/");
            sb.Append(context.RouteData.Values["action"]);
            sb.Append("  ");
            sb.Append("\r\n");
            return sb.ToString();
        }


        private string GetExceptionMessage(ExceptionContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Result:");
            sb.Append(context.Exception.Message);
            return sb.ToString();
        }
    }
}
