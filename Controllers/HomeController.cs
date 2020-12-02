using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EShopDemo.Models;
using EShopDemo.Data;
using System.Dynamic;



namespace EShopDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            var listCategoria=_context.Categorias.ToList();
            var listProducto=_context.Productos.ToList();

            foreach (var categoria in listCategoria){
                string imageBase64Data = Convert.ToBase64String(categoria.Preview);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
                ViewBag.imageDataURL = imageDataURL;
                categoria.imageData = ViewBag.imageDataURL;
            }

            dynamic modelo= new ExpandoObject();
            modelo.Cat= listCategoria;

            foreach(var producto in listProducto){
                string imageBase64Data = Convert.ToBase64String(producto.Picture);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
                ViewBag.imageDataURL = imageDataURL;
                producto.imageData = ViewBag.imageDataURL;
            }
            
            modelo.Productos = listProducto;
 
            return View(modelo);
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
