using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab5RetrieveData
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }

    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=store.db");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new StoreContext();

            await context.Database.EnsureCreatedAsync();

            if (!await context.Products.AnyAsync())
            {
                context.Products.AddRange(
                    new Product { Name = "Laptop", Price = 75000 },
                    new Product { Name = "Rice Bag", Price = 1200 },
                    new Product { Name = "Smartphone", Price = 30000 },
                    new Product { Name = "Refrigerator", Price = 45000 },
                    new Product { Name = "TV", Price = 55000 },
                    new Product { Name = "Washing Machine", Price = 40000 },
                    new Product { Name = "AC", Price = 60000 },
                    new Product { Name = "Headphones", Price = 2000 }
                );
                await context.SaveChangesAsync();
            }

            var products = await context.Products.ToListAsync();
            Console.WriteLine("All Products:");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ₹{p.Price}");

            var product = await context.Products.FindAsync(1);
            Console.WriteLine($"\nFound by ID: {product?.Name}");

            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($"\nFirst Expensive (>₹50000): {expensive?.Name}");
        }
    }
}
