using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public ActionResult<IEnumerable<string>> GetActiveTasks()
        {
            _logger.LogInformation("Getting task ids");
            var taskids = _retriever.GetActiveTasks();
            return Ok(taskids);
        }
    }
}