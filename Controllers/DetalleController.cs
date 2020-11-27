using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EShopDemo.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ILogger<DetalleController> _logger;

        public DetalleController(ILogger<DetalleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}