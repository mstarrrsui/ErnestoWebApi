using System;
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
                var apiresult = new ApiResultModel<TaskDetailsModel[]>
                {
                    isSuccess = true,
                    Result = taskmodels
                };
                return StatusCode(200, apiresult);
            }
            catch (Exception e)
            {
                var apiresult = new ApiResultModel<TaskDetailsModel[]>
                {
                    isSuccess = false,
                    ErrorMessage = e.Message,
                    ErrorType = e.GetType().ToString()
                };
                return StatusCode(523, apiresult);
            }
        }
    }

    public class ApiResultModel<TResult>
    {
        public bool isSuccess { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public TResult Result { get; set; }

    }
}