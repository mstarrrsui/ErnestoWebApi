﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.TaskApi.Models;
using Shared.TaskApi.Services.Tasks;

namespace Shared.TaskApi.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly TaskDataRetriever _retriever;

        public TaskController(ILogger<TaskController> logger, TaskDataRetriever retriever)
        {
            this._logger = logger;
            this._retriever = retriever;
        }

        // GET api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetActiveTasks()
        {
            try
            {
                _logger.LogInformation("Getting task ids");
                var taskids = await _retriever.GetActiveTasks();
                var taskmodels = taskids
                    .Select(id => new TaskDetailsModel { Id = id, Note = $"Task {id}" })
                    .ToArray();
                return this.Success(taskmodels);
            }
            catch (Exception e)
            {
                return this.Error("Get active tasks", e);
            }
        }
    }

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
                ErrorMessage = message + ". " + exception.ToString() // FIXME: never expose internal details
            };
            return controller.StatusCode(523, apiresult);
        }
    }
}