using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JaguarWeb.Models;
using JaguarWeb.Clients;
using System.Net.Http;
using JaguarWeb.Services;

namespace JaguarWeb.Controllers
{
    public class AnalyseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JaguarWebAPIService _client;

        public AnalyseController(ILogger<HomeController> logger, JaguarWebAPIService client)
        {
            _logger = logger;
            _client = client;
        }
        
        [Route("Project/{id}")]
        public async Task<IActionResult> Project(string id)
        {            
            var analyse = await _client.AnalysisControlFlowAllAsync();

            return View("Project", analyse.Where(x=>x.ProjectID == id).ToList());
        }
        
        [Route("Analyse/{id:length(24)}")]
        public async Task<IActionResult> Index(string id)
        {            
            var analyse = await _client.AnalysisControlFlowGETAsync(id);

            return View(analyse);
        }

        [Route("Analyse/{id:length(24)}/{fullName}")]
        public async Task<IActionResult> Index(string id, string fullName)
        {            
            var analyse = await _client.AnalysisControlFlowGETAsync(id);
            ViewData["FullName"] = fullName;
            return View("Classes", analyse);
        }

        [Route("Analyse/{id:length(24)}/{fullName}/{line}")]
        public async Task<IActionResult> Index(string id, string fullName, int line)
        {            
            var analyse = await _client.AnalysisControlFlowGETAsync(id);
            ViewData["Line"] = line.ToString();
            ViewData["FullName"] = fullName;
            return View("Code", analyse);
        }
    }
}
