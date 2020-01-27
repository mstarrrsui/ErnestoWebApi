using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.TaskApi.Controllers.Extensions;
using Shared.TaskApi.Models;
using Shared.TaskApi.Services.Tasks;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Shared.TaskApi.Controllers
{
    [ApiController]
    [Route("user")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly TaskDataRetriever _retriever;

        public UserController(ILogger<UserController> logger, TaskDataRetriever retriever)
        {
            this._logger = logger;
            this._retriever = retriever;
        }

        [HttpGet]
        public async Task<ActionResult<TaskDetailsModel[]>> GetActiveTasks()
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