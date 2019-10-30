using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.TaskApi.Models;
using Shared.TaskApi.Services.Tasks;

namespace Shared.TaskApi.Controllers
{
    [Route("api/stacks")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly StackDataRetriever _retriever;

        public StackController(ILogger<TaskController> logger, StackDataRetriever retriever)
        {
            this._logger = logger;
            this._retriever = retriever;
        }

        // GET api/stacks
        [HttpGet]
        public async Task<ActionResult<string>> GetDepartmentStacks()
        {

            try
            {
                _logger.LogInformation("Getting stacks");
                var taskids = await _retriever.GetDepartmentStacks();
                var taskmodels = taskids
                    .Select(id => new StackDetailsModel { Id = id, Name = $"Stack {id}" })
                    .ToArray();
                var apiresult = new ApiResultModel<StackDetailsModel[]>
                {
                    isSuccess = true,
                    Result = taskmodels
                };
                return this.Success(taskmodels);
            }
            catch (Exception e)
            {
                var apiresult = new ApiResultModel<StackDetailsModel[]>
                {
                    isSuccess = false,
                    ErrorMessage = e.Message,
                    ErrorType = e.GetType().ToString()
                };
                return this.Error("Error getting stacks", e);
            }
        }
    }

}