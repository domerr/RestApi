using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace RestApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBModelContainter(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DBModelContainter>>()))
            {
                // Look for any seeds.

                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }


                context.Product.AddRange(
                    new Products
                    {
                        Id = 1,
                        Name = "Pen",
                        Sku = 522,
                        Description = "Hello world2!"
                    },

                    new Products
                    {
                        Id = 2,
                        Name = "Book",
                        Sku = 521,
                        Description = "Hello world!"
                    }
                );


                context.Pricelist.AddRange(
                    new Pricelists
                    {
                        Id = 1,
                        Name = "Pen",
                        Currency = "€"
                    },

                    new Pricelists
                    {
                        Id = 2,
                        Name = "Pen",
                        Currency = "$"
                    },

                    new Pricelists
                    {
                        Id = 3,
                        Name = "Book",
                        Currency = "€"
                    },

                    new Pricelists
                    {
                        Id = 4,
                        Name = "Book",
                        Currency = "$"
                    }
                );

                context.Price.AddRange(
                    new Prices
                    {
                        Id = 1,
                        PricelistId = 1,
                        ProductId = 1,
                        Amount = 4
                    },

                    new Prices
                    {
                        Id = 2,
                        PricelistId = 2,
                        ProductId = 1,
                        Amount = 3
                    },

                    new Prices
                    {
                        Id = 3,
                        PricelistId = 3,
                        ProductId = 2,
                        Amount = 1
                    },

                    new Prices
                    {
                        Id = 4,
                        PricelistId = 4,
                        ProductId = 2,
                        Amount = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}