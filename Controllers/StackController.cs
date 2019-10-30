using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ErnestoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.TaskApi.Data.Entities;
using Shared.TaskApi.Services.Tasks;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [Route("api/stacks")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly SiteSettings _SiteSettings;
        private readonly RsuiDbContext _DbContext;
        private readonly StackDataRetriever _StackDataRetriever;
        private readonly IMapper _ModelMapper;

        public StackController(
            IOptions<SiteSettings> siteSettings, 
            RsuiDbContext dbContext,
            IMapper modelMapper,
            StackDataRetriever stackDataRetriever
            )
        {
            _SiteSettings = siteSettings.Value;
            _DbContext = dbContext;
            _StackDataRetriever  = stackDataRetriever;
            _ModelMapper = modelMapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetDepartmentStacks()
        {
            try
            {
                var stacks = await _DbContext
                    .TaskType
                    .Include(inst => inst.TaskSubType)
                    .AsNoTracking()
                    .ProjectTo<StackDetailsModel>(_ModelMapper.ConfigurationProvider)
                    .ToListAsync();
                // var stackmodels = _ModelMapper.Map<StackDetailsModel[]>(stacks);
                return this.Success(stacks);
            }
            catch (Exception ex)
            {
                return this.Error("Get department stacks", ex);
            }
        }
    }
}