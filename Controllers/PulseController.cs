using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("pulse")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class PulseController : ControllerBase
    {
        private readonly SiteSettings _SiteSettings;
        public PulseController(IOptions<SiteSettings> siteSettings)
        {
            _SiteSettings = siteSettings.Value;
        }

        [HttpGet("ping")]
        public ActionResult<string> Get()
        {
            return Ok($"Pong {_SiteSettings.Version}");
        }
    }

}