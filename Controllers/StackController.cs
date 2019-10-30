using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.TaskApi.Data.Entities;
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
        public async Task<ActionResult<ApiResultModel<StackDetailsModel[]>>> GetDepartmentStacks()
        {

            try
            {
                _logger.LogInformation("Getting stacks");
                var stacks = await _retriever.GetTaskTypes();
                var apiresult = new ApiResultModel<StackDetailsModel[]>
                {
                    isSuccess = true,
                    Result = stacks
                    .Select(s => new StackDetailsModel { Id = s.TaskTypeId, Name = s.Description })
                    .ToArray()
                };
                return this.Success(apiresult);
            }
            catch (Exception e)
            {
                var apiresult = new ApiResultModel<object>
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