using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.TaskApi.Controllers.Extensions;
using Shared.TaskApi.Models;
using Shared.TaskApi.Services.Tasks;

namespace Shared.TaskApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly TaskDataRetriever _retriever;

        public TaskController(ILogger<TaskController> logger, TaskDataRetriever retriever)
        {
            this._logger = logger;
            this._retriever = retriever;
        }

        // TODO come back and add code to actually hit the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetActiveTasks()
        {
            try
            {
                _logger.LogInformation("Getting task ids for all");
                var taskids = await _retriever.GetActiveTasks();
                var taskmodels = taskids
                    .Select(id => new TaskDetailsModel { Id = id, Note = $"Task {id}" })
                    .ToArray();
                return this.Success(taskmodels);
            }
            catch (Exception e)
            {
                return this.Error("Get active tasks failed", e);
            }
        }
    }
}