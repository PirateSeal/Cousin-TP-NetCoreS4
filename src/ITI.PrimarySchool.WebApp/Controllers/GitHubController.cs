﻿using System.Security.Claims;
using System.Threading.Tasks;
using ITI.PrimarySchool.WebApp.Authentication;
using ITI.PrimarySchool.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class GitHubController : Controller
    {
        private readonly GitHubService _gitHubService;

        public GitHubController( GitHubService gitHubService )
        {
            _gitHubService = gitHubService;
        }

        [HttpGet( "Following" )]
        public async Task<IActionResult> GetFollowedStudents()
        {
            int userId = int.Parse( User.FindFirst( ClaimTypes.NameIdentifier ).Value );
            var result = await _gitHubService.GetFollowedStudents( userId );
            return this.CreateResult( result );
        }
    }
}
