﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shared.TaskApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.TaskApi.Controllers.Extensions;
using Shared.TaskApi.Data.Contexts;
using Shared.TaskApi.Services.Tasks;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [ApiController]
    [Route("stacks")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
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
            _StackDataRetriever = stackDataRetriever;
            _ModelMapper = modelMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentStacks()
        {
            try
            {
                var username = HttpContext.GetUserNameOrThrow();
                // TODO next objective, get the active user from the token and ensure the user can edit tasks first
                var stacks = await _DbContext
                    .TaskType
                    .Include(inst => inst.TaskSubType)
                    .Where(inst => inst.ProfitCenterKey == 3)
                    .AsNoTracking()
                    .ProjectTo<StackDetailsModel>(_ModelMapper.ConfigurationProvider)
                    .ToListAsync();
                return this.Success(stacks);
            }
            catch (Exception ex)
            {
                return this.Error("Get department stacks", ex);
            }
        }
    }
}