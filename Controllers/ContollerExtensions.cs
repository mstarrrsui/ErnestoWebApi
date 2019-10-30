using System;
using Microsoft.AspNetCore.Mvc;
using Shared.TaskApi.Models;

namespace Shared.TaskApi.Controllers
{
    internal static class ContollerExtensions
    {
        internal static ActionResult Success<TResult>(this ControllerBase controller, TResult result)
        {
            var apiresult = new ApiResultModel<TResult>
            {
                isSuccess = true,
                Result = result
            };
            return controller.StatusCode(200, apiresult);
        }

        internal static ActionResult Error(this ControllerBase controller, string message, Exception exception)
        {
            var apiresult = new ApiResultModel<object>
            {
                isSuccess = false,
                ErrorType = exception.GetType().Name,
                ErrorMessage = message + ". " + exception.ToString()
            };
            return controller.StatusCode(523, apiresult);
        }
    }
}