using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShopDemo.Models;
using EShopDemo.Data;
using System.Dynamic;
using Microsoft.Extensions.Logging;


namespace EShopDemo.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ILogger<DetalleController> _logger;
        private readonly ApplicationDbContext _context;

        public DetalleController(ILogger<DetalleController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(Producto producto)
        {
            var listProductos=_context.Productos.ToList();
            var listUsuarios=_context.Usuarios.ToList();
            dynamic modelo= new ExpandoObject();
            Producto prod= new Producto();

            for(int i=0; i<listProductos.Count; i++){
                prod=listProductos[i];
                if(prod.catID==producto.ID){
                    break;
                }               
            }

            for(int i=0; i<=listUsuarios.Count; i++){
                Usuario user=listUsuarios[i];
                if(user.Id==prod.userID){
                    modelo.Usuario=user;
                    break;
                }
            }

            string imageBase64Data = Convert.ToBase64String(prod.Picture);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
            ViewBag.imageDataURL = imageDataURL;
            prod.imageData = ViewBag.imageDataURL;

            modelo.Producto=prod;

            return View(modelo);
        }

    }
}