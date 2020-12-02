using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EShopDemo.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;

        public CarritoController(ILogger<CarritoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}