using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EShopDemo.Data{

    public class DatabaseContext : DbContext{

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

    }
}