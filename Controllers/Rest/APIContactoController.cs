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
    [Route("api/contactos")]
    public class APIContactoController : ControllerBase
    {
       private readonly ILogger<APIContactoController> _logger;
       private readonly ApplicationDbContext _context;

        public APIContactoController(ILogger<APIContactoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        
        public IEnumerable<Contacto> ListContactos()
        {
             var listContactos=_context.Contactos.OrderBy(u => u.ID).ToList();   
             return listContactos.ToArray();
        }

        [HttpGet("{id}")]
        public Contacto GetContacto(int? id)
        {
            var contacto =  _context.Contactos.Find(id);
            return contacto;
        }

        [HttpPost]
        public Contacto CreateContacto(Contacto contacto){
            _context.Add(contacto);
            _context.SaveChanges();
            return contacto;
        }
    }
}