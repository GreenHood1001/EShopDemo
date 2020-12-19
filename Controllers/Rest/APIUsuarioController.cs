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

namespace EShopDemo.Controllers.Rest
{
    [ApiController]
    [Route("api/usuarios")]
    public class APIUsuarioController : ControllerBase
    {
       private readonly ILogger<APIUsuarioController> _logger;
       private readonly ApplicationDbContext _context;

        public APIUsuarioController(ILogger<APIUsuarioController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        
        public IEnumerable<Usuario> ListUsuarios()
        {
             var listUsuarios=_context.Usuarios.OrderBy(u => u.Id).ToList();   
             return listUsuarios.ToArray();
        }

        [HttpGet("{id}")]
        public Usuario GetUsuario(int? id)
        {
            var usuario =  _context.Usuarios.Find(id);
            return usuario;
        }

        [HttpPost]
        public Usuario CreateUsuario(Usuario usuario){
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
}