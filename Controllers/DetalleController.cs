using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShopDemo.Models;
using EShopDemo.Data;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EShopDemo.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ILogger<DetalleController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public DetalleController(ILogger<DetalleController> logger, ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(Producto producto)
        {
            var listProductos=_context.Productos.ToList();
            var listUsuarios=_context.Usuarios.ToList();
            dynamic modelo= new ExpandoObject();
            var prod= new List<Producto>();

            for(int i=0; i<listProductos.Count; i++){
                prod.Add(listProductos[i]);
                if(prod[0].ID==producto.ID){
                    break;
                }else{
                    prod.RemoveAt(0);
                }               
            }

            for(int i=0; i<=listUsuarios.Count; i++){
                Usuario usu=listUsuarios[i];
                if(usu.Id==prod[0].userID){
                    modelo.Usuario=usu;
                    break;
                }
            }

            string imageBase64Data = Convert.ToBase64String(prod[0].Picture);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
            ViewBag.imageDataURL = imageDataURL;
            prod[0].imageData = ViewBag.imageDataURL;

            modelo.Producto=prod;  

            return View(modelo);
        }

        [HttpPost]
        public IActionResult AddCart(Producto producto)
        { 
            if (_signInManager.IsSignedIn(User))
            { 
                var listProductos= _context.Productos.ToList();
                if(producto.ID<=listProductos.Count)
                {
                    Carrito carrito = new Carrito();
                    string email = User.Identity.Name;
                    var user = _userManager.FindByEmailAsync(email);
                    carrito.user_id = _userManager.GetUserId(User);
                    carrito.producto_id = producto.ID;
                    _context.Add(carrito);
                    _context.SaveChanges();
                    Console.WriteLine("Item añadido");
                    return RedirectToAction("Index","Carrito");
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                return LocalRedirect("/Identity/Account/Login");
            }
        }

    }
}