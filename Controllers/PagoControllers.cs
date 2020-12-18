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
using Microsoft.AspNetCore.Identity;


namespace EShopDemo.Controllers
{
    public class PagoController : Controller
    {
        private readonly ILogger<PagoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private List<Carrito> listCarro = new List<Carrito>();

        private List<Producto> listProductos = new List<Producto>();

        public PagoController(ILogger<PagoController> logger, ApplicationDbContext context,SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            listProductos=_context.Productos.ToList();
            listCarro=_context.Carritos.ToList();
        }

        public IActionResult Index()
        {
            if(_signInManager.IsSignedIn(User))
            {
                string email = User.Identity.Name;
                var user = _userManager.FindByEmailAsync(email);
                //se extrae el ID del usuario actualmente logueado
                var userId = _userManager.GetUserId(User);
                var listMostrar= new List<Producto>();
                int total = 0;
                Producto prod= new Producto();
                dynamic model = new ExpandoObject();

                foreach(var carro in listCarro){
                    if(carro.user_id==userId){
                        for(int i=0; i<listProductos.Count; i++){
                            prod=listProductos[i];
                            if(prod.ID==carro.producto_id){
                                string imageBase64Data = Convert.ToBase64String(prod.Picture);
                                string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);
                                ViewBag.imageDataURL = imageDataURL;
                                prod.imageData = ViewBag.imageDataURL;
                                total+=prod.Price;
                                listMostrar.Add(prod);
                                break;
                            }
                        }
                    }
                }

                model.Mostrar = listMostrar;
                model.Total = total;
                model.Pago = new Pago();
                return View(model);
            }
            else
            {
                return LocalRedirect("/Identity/Account/Login");
            }
        }
        
        [HttpPost]
        public IActionResult Confirmacion(Pago pago){
            
            if(_signInManager.IsSignedIn(User))
            {
                if(ModelState.IsValid){
                    string email = User.Identity.Name;
                    var user = _userManager.FindByEmailAsync(email);
                    //se extrae el ID del usuario actualmente logueado
                    var userId = _userManager.GetUserId(User);
                    
                    var listProd= new List<Producto>();
                    Producto prod= new Producto();
                    dynamic model = new ExpandoObject();

                    foreach(var carro in listCarro){
                        if(carro.user_id==userId){
                            for(int i=0; i<listProductos.Count; i++){
                                prod=listProductos[i];
                                if(prod.ID==carro.producto_id){
                                    listProd.Add(prod);
                                    
                                }
                            }
                            _context.Remove(carro);
                        }                       
                    }
                    _context.SaveChanges();

                    model.Productos=listProd;
                    Console.WriteLine("Successful payment");
                    return View(model);

                }else{
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return LocalRedirect("/Identity/Account/Login");
            }
        }
    }
}