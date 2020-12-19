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
    // to do agregar controller para agregar prodductos via IU
public class ServicioControllers : Controller
    {
        private readonly ILogger<ServicioControllers> _logger;

        private readonly ApplicationDbContext  _context;

        public ServicioControllers(ILogger<ServicioControllers> logger, ApplicationDbContext  context )
        {
            _logger = logger;
            _context=context;
        }

        public IActionResult Index(Servicio servicio)
        {
            var listProductos=_context.Productos.ToList();
            var listServicios=_context.Categorias.ToList();
            var listMostrar= new List<Producto>();
            string titulo="Servicios de "; 
            string desc= "Aqui podrás encontrar los mejores servicios de ";
            dynamic model = new ExpandoObject();

            for(int i=0; i<listServicios.Count; i++){
                Categoria cat= listServicios[i];
                if(cat.ID==servicio.ID){
                    titulo = titulo+cat.Name;
                    desc = desc+cat.Name;
                    string imageBase64Data = Convert.ToBase64String(cat.Banner);
                    string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
                    ViewBag.imageDataURL = imageDataURL;
                    model.Banner=imageDataURL;
                }
            }

            

            

            model.Titulo = titulo;    
            model.Descripcion = desc;       
            model.Mostrar = listMostrar;
            return View(model);
        }
    
    }
}
