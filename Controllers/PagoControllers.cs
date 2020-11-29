using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EShopDemo.Controllers
{
    public class PagoController : Controller
    {
        private readonly ILogger<PagoController> _logger;

        public PagoController(ILogger<PagoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}