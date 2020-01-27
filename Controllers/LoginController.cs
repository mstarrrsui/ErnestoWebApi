using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shared.TaskApi.Controllers.Models;
using Shared.TaskApi.Factories;
using Shared.TaskApi.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.TaskApi.Controllers.Extensions;
using Shared.TaskApi.Data.Contexts;
using Shared.TaskApi.Services.Tasks;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [ApiController]
    [Route("login")]
    [Authorize(AuthenticationSchemes = "Windows")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class LoginController : ControllerBase
    {
        private readonly SiteSettings _SiteSettings;
        private readonly RsuiDbContext _DbContext;
        private readonly StackDataRetriever _StackDataRetriever;
        private readonly IMapper _ModelMapper;

        public LoginController(
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
        public async Task<IActionResult> Login()
        {
            try
            {
                var username = HttpContext.GetUserNameOrThrow();
                var activeuser = await _DbContext.Employee
                    .Where(inst => inst.EmpUserProfile == username)
                    .Where(inst => inst.EmpActiveCode == "A")
                    .AsNoTracking()
                    .ProjectTo<ActiveUser>(_ModelMapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();
                var activeuserjson = JsonConvert.SerializeObject(activeuser);
                var activeuserclaim = new List<Claim>{new Claim("ActiveUser", activeuserjson)};
                var activeusertoken = TokenFactory.CreateJwtToken(username, activeuserclaim, out var expires);

                var userdetails = _ModelMapper.Map<UserDetailsModel>(activeuser);
                userdetails.Token = activeusertoken;
                userdetails.TokenTtl = expires;
                return this.Success(userdetails);
            }
            catch (Exception ex)
            {
                return this.Error("Login failed", ex);
            }
        }
    }
}