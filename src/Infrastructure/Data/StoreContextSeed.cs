using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsStoreOnWeb.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsStoreOnWeb.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                storeContext.Database.Migrate();

                if (!await storeContext.CategoryTypes.AnyAsync())
                {
                    await storeContext.CategoryTypes.AddRangeAsync(
                        GetPreconfiguredCategories());

                    await storeContext.SaveChangesAsync();
                }

                if (!await storeContext.Products.AnyAsync())
                {
                    await storeContext.Products.AddRangeAsync(
                        GetPreconfiguredProducts());

                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<StoreContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(storeContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<CategoryType> GetPreconfiguredCategories()
        {
            return new List<CategoryType>()
            {
                new CategoryType("Watersports"),
                new CategoryType("Soccer"),
                new CategoryType("Chess")
            };
        }

        static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product("Kayak", "A boat for one person", 275.00m, 1),
                new Product("Lifejacket", "Protective and fashionable", 48.95m, 1),
                new Product("Soccer Ball", "FIFA-approved size and weight", 19.50m, 2),
                new Product("Corner Flags", "Give your playing field a professional touch", 34.95m, 2),
                new Product("Stadium", "Flat-packed 35,000-seat stadium", 79500.00m, 2),
                new Product("Thinking Cap", "Improve brain efficiency by 75%", 16.00m, 3),
                new Product("Unsteady Chair", "Secretly give your opponent a disadvantage", 29.95m, 3),
                new Product("Human Chess Board", "A fun game for the family", 75.00m, 3),
                new Product("Bling-Bling King", "Gold-plated, diamond-studded King", 1200.00m, 3)
            };
        }
    }
}