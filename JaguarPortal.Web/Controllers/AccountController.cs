using AutoMapper;
using JaguarPortal.Web.Models.Account;
using JaguarPortal.WebApi.Client.Interfaces;
using JaguarPortal.WebApi.Models.Response;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace JaguarPortal.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserClient userClient;
        private readonly IMapper mapper;

        public AccountController(IUserClient userClient, IMapper mapper)
        {
            this.userClient = userClient;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                WebApi.Models.Request.UserInsertRequest user = mapper.Map<WebApi.Models.Request.UserInsertRequest>(model);
                userClient.Register(user);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            WebApi.Models.Request.UserAuthenticationRequest login = mapper.Map<WebApi.Models.Request.UserAuthenticationRequest>(model);

            UserAuthenticationResponse response = await userClient.Authenticate(login);

            var user = await userClient.GetByLogin(model.Login, response.AccessToken);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("AccessToken", response.AccessToken),
                new Claim("ExpiresIn", DateTime.UtcNow.AddSeconds(response.ExpiresIn).ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);


            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
