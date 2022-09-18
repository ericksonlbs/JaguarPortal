using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using JaguarWebAPI.Models;
using JaguarWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JaguarWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisControlFlowController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AnalysisControlFlowController> _logger;
        private readonly AnalysisControlFlowService _AnalysisControlFlowServices;

        public AnalysisControlFlowController(ILogger<AnalysisControlFlowController> logger, AnalysisControlFlowService AnalysisControlFlowServices, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _AnalysisControlFlowServices = AnalysisControlFlowServices;
        }

        [HttpGet]
        public async Task<List<AnalysisControlFlowModel>> Get() =>
            await _AnalysisControlFlowServices.GetAsync();

        [HttpGet("{id:length(24)}")]        
        [ProducesResponseType(((int)HttpStatusCode.NotFound), Type = typeof(ErrorsModel))]
        [ProducesResponseType(((int)HttpStatusCode.OK), Type = typeof(AnalysisControlFlowModel))]
        public async Task<ActionResult<AnalysisControlFlowModel>> Get(string id)
        {

            var AnalysisControlFlowModel = await _AnalysisControlFlowServices.GetAsync(id);

            if (AnalysisControlFlowModel is null)
            {
                return NotFound(ErrorsUtil.CreateErrorsModel(0, "Object NotFound"));
            }

            return AnalysisControlFlowModel;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnalysisControlFlowNewModel newAnalysisControlFlowModel)
        {
            var analysisControlFlowModel = _mapper.Map<AnalysisControlFlowModel>(newAnalysisControlFlowModel);
            analysisControlFlowModel.CreatedDate = DateTime.UtcNow;

            await _AnalysisControlFlowServices.CreateAsync(analysisControlFlowModel);

            return CreatedAtAction(nameof(Get), new { id = analysisControlFlowModel.Id }, analysisControlFlowModel);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, AnalysisControlFlowModel updatedAnalysisControlFlowModel)
        {
            var AnalysisControlFlowModel = await _AnalysisControlFlowServices.GetAsync(id);

            if (AnalysisControlFlowModel is null)
            {
                return NotFound();
            }

            updatedAnalysisControlFlowModel.Id = AnalysisControlFlowModel.Id;

            await _AnalysisControlFlowServices.UpdateAsync(id, updatedAnalysisControlFlowModel);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var AnalysisControlFlowModel = await _AnalysisControlFlowServices.GetAsync(id);

            if (AnalysisControlFlowModel is null)
            {
                return NotFound();
            }

            await _AnalysisControlFlowServices.RemoveAsync(AnalysisControlFlowModel.Id);

            return NoContent();
        }
    }
}
