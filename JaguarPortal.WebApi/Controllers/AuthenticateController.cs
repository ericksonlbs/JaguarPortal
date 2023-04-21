using AutoMapper;
using JaguarPortal.Core.Models;
using JaguarPortal.Services.Interfaces;
using JaguarPortal.WebApi.Models.Request;
using JaguarPortal.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JaguarPortal.WebApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ISecurityService securityService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AuthenticateController(IUserService userService, ISecurityService securityService, ITokenService tokenService, IMapper mapper)
        {
            this.userService = userService;
            this.securityService = securityService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(((int)HttpStatusCode.OK), Type = typeof(UserAuthenticationResponse))]
        public async Task<IActionResult> Post(UserAuthenticationRequest model)
        {
            Token token;

            if (await userService.ValidateLogin(model.Login, model.Password))
            {
                var user = await userService.GetByLogin(model.Login);
                token = tokenService.GenerateToken(user);

                UserAuthenticationResponse response = mapper.Map<UserAuthenticationResponse>(token);
                return Ok(response);
            }

            return NotFound();
        }
    }
}
