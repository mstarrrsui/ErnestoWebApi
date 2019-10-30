using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.TaskApi.Services.Tasks;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [Route("api/stacks")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly SiteSettings _SiteSettings;
        private readonly StackDataRetriever _StackDataRetriever;

        public StackController(IOptions<SiteSettings> siteSettings, StackDataRetriever stackDataRetriever)
        {
            _SiteSettings = siteSettings.Value;
            _StackDataRetriever  = stackDataRetriever;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetDepartmentStacks()
        {
            try
            {
                var stackids = await _StackDataRetriever.GetTaskTypes();
                return this.Success(stackids);
            }
            catch (Exception ex)
            {
                return this.Error("Get department stacks", ex);
            }
        }
    }

}