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
    [Route("[controller]")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectService service;
        private readonly IMapper mapper;

        public ProjectsController(ILogger<ProjectsController> logger, IProjectService service, IMapper mapper)
        {
            _logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(((int)HttpStatusCode.OK), Type = typeof(IEnumerable<ProjectResponse>))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Core.Models.Project> users = await service.GetList();
            IEnumerable<ProjectResponse> response = mapper.Map<IEnumerable<ProjectResponse>>(users);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(((int)HttpStatusCode.OK), Type = typeof(ProjectResponse))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        [ProducesResponseType(((int)HttpStatusCode.NotFound))]
        public async Task<IActionResult> Get(long id)
        {
            Core.Models.Project proj;
            try
            {
                proj = await service.GetById(id);
            }
            catch (NotFoundObjectException)
            {
                return NotFound();
            }

            ProjectResponse model = mapper.Map<ProjectResponse>(proj);

            return Ok(model); ;
        }

        [HttpPost]
        [ProducesResponseType(((int)HttpStatusCode.NoContent))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Post(ProjectInsertRequest model)
        {
            Core.Models.Project proj = mapper.Map<Core.Models.Project>(model);

            proj.CreatedUser = User.Identity?.Name ?? string.Empty;
            proj.CreatedDate = DateTime.UtcNow;
            await service.Insert(proj);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(((int)HttpStatusCode.NoContent))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Put([FromQuery] long id, [FromBody] ProjectUpdateRequest model)
        {
            Core.Models.Project proj = mapper.Map<Core.Models.Project>(model);
            await service.Update(id, proj);

            return NoContent();
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