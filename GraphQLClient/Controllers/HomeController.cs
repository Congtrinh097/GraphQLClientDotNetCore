using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQLClient.Models;
using GraphQLClient.GraphQLConsumers;
using System.Text.Json.Serialization;

namespace GraphQLClient.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventConsumer _eventConsumer;
        public HomeController(ILogger<HomeController> logger, IEventConsumer eventConsumer)
        {
            _logger = logger;
            _eventConsumer = eventConsumer;
        }

        public async Task<IActionResult> Index()
        {
            var data = _eventConsumer.GetDataData().Result;
            return Ok(data);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
