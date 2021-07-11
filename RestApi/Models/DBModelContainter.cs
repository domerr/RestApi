using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class DBModelContainter : DbContext
    {
        public DBModelContainter(DbContextOptions<DBModelContainter> options)
            : base(options)
        {
        }

        public DbSet<Prices> Price { get; set; }
        public DbSet<Pricelists> Pricelist { get; set; }
        public DbSet<Products> Product { get; set; }

    }

}
