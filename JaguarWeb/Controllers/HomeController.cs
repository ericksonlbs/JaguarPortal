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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JaguarWebAPIService _client;

        public HomeController(ILogger<HomeController> logger, JaguarWebAPIService client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            
            var analysis = await _client.AnalysisControlFlowAllAsync();

            return View(analysis);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
