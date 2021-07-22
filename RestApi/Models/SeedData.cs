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
                        Description = "Good looking pen"
                    },

                    new Products
                    {
                        Id = 2,
                        Name = "Book",
                        Sku = 521,
                        Description = "Good looking book"
                    },

                    new Products
                    {
                        Id = 3,
                        Name = "Keyboard",
                        Sku = 523,
                        Description = "Good looking keyboard"
                    },
                    new Products
                    {
                        Id = 4,
                        Name = "Mouse",
                        Sku = 524,
                        Description = "Good looking mouse"
                    }
                );


                context.Pricelist.AddRange(
                    new Pricelists
                    {
                        Id = 1,
                        Name = "Price for Norway",
                        Currency = "NOK"
                    },

                    new Pricelists
                    {
                        Id = 2,
                        Name = "Price for Poland",
                        Currency = "PLN"
                    }
                );

                context.Price.AddRange(
                    new Prices
                    {
                        Id = 1,
                        PricelistId = 1,
                        ProductId = 1,
                        Amount = 20
                    },

                    new Prices
                    {
                        Id = 2,
                        PricelistId = 2,
                        ProductId = 1,
                        Amount = 50
                    },

                    new Prices
                    {
                        Id = 3,
                        PricelistId = 1,
                        ProductId = 2,
                        Amount = 40
                    },

                    new Prices
                    {
                        Id = 4,
                        PricelistId = 2,
                        ProductId = 2,
                        Amount = 80
                    },
                    new Prices
                    {
                        Id = 5,
                        PricelistId = 1,
                        ProductId = 3,
                        Amount = 200
                    },

                    new Prices
                    {
                        Id = 6,
                        PricelistId = 2,
                        ProductId = 3,
                        Amount = 600
                    },

                    new Prices
                    {
                        Id = 7,
                        PricelistId = 1,
                        ProductId = 4,
                        Amount = 4000
                    },

                    new Prices
                    {
                        Id = 8,
                        PricelistId = 2,
                        ProductId = 4,
                        Amount = 80000
                    }
                );

                context.SaveChanges();
            }
        }
    }
}