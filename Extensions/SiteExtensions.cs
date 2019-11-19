using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.TaskApi.Models;

namespace Shared.TaskApi.Controllers.Extensions
{
    public static class SiteExtensions
    {
        public static string GetUserName(this HttpContext context)
        {
            if (context != null)
            {
                var identity = context?.User?.Identity?.Name;
                if (!string.IsNullOrEmpty(identity))
                {
                    if (identity.Contains("\\"))
                    {
                        var parts = identity.Split("\\").ToList();
                        if (parts.Count == 2)
                        {
                            return parts.Last();
                        }
                    }
                    return identity;
                }
            }
            return null;
        }

        public static string GetUserNameOrThrow(this HttpContext context)
        {
            var username = context.GetUserName();
            if (string.IsNullOrEmpty(username)) throw new Exception("We do not know wyho you are");
            return username;
        }

        public static ActionResult Success<TResult>(this ControllerBase controller, TResult result)
        {
            var apiresult = new ApiResultModel<TResult>
            {
                isSuccess = true,
                Result = result
            };
            return controller.StatusCode(200, apiresult);
        }

        public static ActionResult Error(this ControllerBase controller, string message, Exception exception)
        {
            var apiresult = new ApiResultModel<object>
            {
                isSuccess = false,
                ErrorType = exception.GetType().Name,
                ErrorMessage = message + ". " + exception.ToString() // FIXME never expose internal details
            };
            return controller.StatusCode(523, apiresult);
        }
    }
}