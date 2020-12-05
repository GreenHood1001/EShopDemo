using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EShopDemo.Data;
using EShopDemo.Models;

namespace EShopDemo.Controllers
{
    public class UsuarioController : Controller
    {
private readonly ILogger<UsuarioController> _logger;
       private readonly ApplicationDbContext _context;


        public UsuarioController(ILogger<UsuarioController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Enviar(Usuario objFormulario)
        {
                objFormulario.Respuesta = "HEMOS PROCESADO SU SOLICITUD";
                _context.Add(objFormulario);
                _context.SaveChanges();
                return View("index", objFormulario);
        }

        public IActionResult Information()
        {
            return View();
        }
    }
}