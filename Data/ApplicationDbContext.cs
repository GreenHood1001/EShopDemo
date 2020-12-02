using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EShopDemo.Models;

namespace EShopDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EShopDemo.Models.Usuario> Usuarios { get; set; }
        public DbSet<EShopDemo.Models.Contacto> Contactos { get; set; }
        public DbSet<EShopDemo.Models.Categoria> Categorias { get; set; }

        public DbSet<EShopDemo.Models.Producto> Productos { get; set; }

    }
}
