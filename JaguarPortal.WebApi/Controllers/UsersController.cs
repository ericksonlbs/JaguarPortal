using AutoMapper;
using JaguarPortal.Core.Exceptions;
using JaguarPortal.Services.Interfaces;
using JaguarPortal.WebApi.Models.Request;
using JaguarPortal.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JaguarPortal.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService service;
        private readonly IMapper mapper;

        public UsersController(ILogger<UsersController> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<IActionResult> Get(long id)
        {
            Core.Models.User proj;
            try
            {
                proj = await service.GetById(id);
            }
            catch (NotFoundObjectException)
            {
                return NotFound();
            }

            UserResponse model = mapper.Map<UserResponse>(proj);

            return Ok(model); ;
        }

        [HttpGet("ByLogin/{login}")]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<IActionResult> GetByLogin(string login)
        {
            Core.Models.User user;
            try
            {
                user = await service.GetByLogin(login);
            }
            catch (NotFoundObjectException)
            {
                return NotFound();
            }

            UserResponse model = mapper.Map<UserResponse>(user);

            return Ok(model); ;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Post(UserInsertRequest model)
        {
            Core.Models.User proj = mapper.Map<Core.Models.User>(model);

            await service.Insert(proj);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(((int)HttpStatusCode.OK), Type = typeof(IEnumerable<UserResponse>))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Core.Models.User> users = await service.GetList();
            IEnumerable<UserResponse> response = mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Put([FromQuery] long id, [FromBody] UserUpdateRequest model)
        {
            Core.Models.User user = mapper.Map<Core.Models.User>(model);

            await service.Update(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(((int)HttpStatusCode.NoContent))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await service.Delete(id);
            }
            catch (NotFoundObjectException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}