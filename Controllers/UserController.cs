using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ErnestoWebApi.Controllers.Models;
using ErnestoWebApi.Factories;
using ErnestoWebApi.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.TaskApi.Controllers.Extensions;
using Shared.TaskApi.Data.Entities;
using Shared.TaskApi.Services.Tasks;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    [Authorize(AuthenticationSchemes = "Windows")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class UserController : ControllerBase
    {
        private readonly SiteSettings _SiteSettings;
        private readonly RsuiDbContext _DbContext;
        private readonly StackDataRetriever _StackDataRetriever;
        private readonly IMapper _ModelMapper;

        public UserController(
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
                var activeuserclaim = new Claim("ActiveUser", activeuserjson);
                var activeusertoken = TokenFactory.CreateJwtToken(username, activeuserclaim);

                var userdetails = _ModelMapper.Map<UserDetailsModel>(activeuser);
                userdetails.Token = activeusertoken;
                // TODO give this guy a time to live and also pass in the security key
                return this.Success(userdetails);
            }
            catch (Exception ex)
            {
                return this.Error("Login failed", ex);
            }
        }
    }
}