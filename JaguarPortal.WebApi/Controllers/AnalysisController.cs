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
    public class AnalysesController : ControllerBase
    {
        private readonly ILogger<AnalysesController> _logger;
        private readonly IAnalysisService service;
        private readonly IMapper mapper;

        public AnalysesController(ILogger<AnalysesController> logger, IAnalysisService service, IMapper mapper)
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
            Core.Models.Analysis proj;
            try
            {
                proj = await service.GetById(id);
            }
            catch (NotFoundObjectException)
            {
                return NotFound();
            }

            AnalysisResponse model = mapper.Map<AnalysisResponse>(proj);

            return Ok(model); ;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(((int)HttpStatusCode.OK))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Post(AnalysisInsertRequest model)
        {
            Core.Models.Analysis proj = mapper.Map<Core.Models.Analysis>(model);
            
            await service.Insert(proj);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(((int)HttpStatusCode.OK), Type = typeof(IEnumerable<AnalysisResponse>))]
        [ProducesResponseType(((int)HttpStatusCode.InternalServerError))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Core.Models.Analysis> Analyses = await service.GetList();            
            IEnumerable<AnalysisResponse> response = mapper.Map<IEnumerable<AnalysisResponse>>(Analyses);
            return Ok(response);
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