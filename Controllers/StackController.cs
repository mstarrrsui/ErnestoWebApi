using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ErnestoWebApi.Models;
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
        private readonly IMapper _ModelMapper;

        public StackController(
            IOptions<SiteSettings> siteSettings, 
            IMapper modelMapper,
            StackDataRetriever stackDataRetriever
            )
        {
            _SiteSettings = siteSettings.Value;
            _StackDataRetriever  = stackDataRetriever;
            _ModelMapper = modelMapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetDepartmentStacks()
        {
            try
            {
                var stacks = await _StackDataRetriever.GetTaskTypes();
                var stackmodels = _ModelMapper.Map<StackDetailsModel[]>(stacks);
                return this.Success(stackmodels);
            }
            catch (Exception ex)
            {
                return this.Error("Get department stacks", ex);
            }
        }
    }
}