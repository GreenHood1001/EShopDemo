using System;
using System.Collections;
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


        [HttpGet("Categoria")]
        public IActionResult Index(int id)
        {
            var listCategoria=_context.Categorias.ToList();
            ArrayList listMostrar= new ArrayList();
            foreach(var categoria in listCategoria){
                if(id==categoria.ID){
                    listMostrar.Add(categoria);
                }
            }
            dynamic modelo = new ExpandoObject();
            modelo.Mostrar = listMostrar;
            return View(modelo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}