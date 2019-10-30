using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [Route("api/pulse")]
    [ApiController]
    public class StacksController : ControllerBase
    {
        private readonly SiteSettings _siteSettings;
        public StacksController(IOptions<SiteSettings> siteSettings)
        {
            this._siteSettings = siteSettings.Value;

        }

        // GET api/values
        [HttpGet("ping")]
        public ActionResult<string> Get()
        {
            return Ok($"pong - version:${this._siteSettings.Version}");
        }
    }

}