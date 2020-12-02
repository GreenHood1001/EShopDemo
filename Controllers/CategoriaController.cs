using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EShopDemo.Models;
using EShopDemo.Data;
using System.Dynamic;
namespace EShopDemo.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ApplicationDbContext _context;

        public CategoriaController(ILogger<CategoriaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(Categoria categoria)
        {
            var listProductos=_context.Productos.ToList();
            var listCategorias=_context.Categorias.ToList();
            var listMostrar= new List<Producto>();
            dynamic model = new ExpandoObject();

            for(int i=0; i<listCategorias.Count; i++){
                Categoria cat= listCategorias[i];
                if(cat.ID==categoria.ID){
                    string imageBase64Data = Convert.ToBase64String(cat.Banner);
                    string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
                    ViewBag.imageDataURL = imageDataURL;
                    model.Banner=imageDataURL;
                }
            }

            foreach(var prod in listProductos){
                if(prod.catID==categoria.ID){
                    listMostrar.Add(prod);
                }
            }

            foreach(var prod in listMostrar){
                string imageBase64Data = Convert.ToBase64String(prod.Picture);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
                ViewBag.imageDataURL = imageDataURL;
                prod.imageData = ViewBag.imageDataURL;
            }

            
            model.Mostrar = listMostrar;
            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}