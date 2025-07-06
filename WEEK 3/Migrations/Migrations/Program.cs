using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Migrations
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class MigrationsContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MigrationsDB;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MigrationsContext())
            {
                // ✅ Check if "Electronics" category exists already
                var categoryExists = context.Categories.Any(c => c.Name == "Electronics");
                var productExists = context.Products.Any(p => p.Name == "Laptop");

                if (!categoryExists && !productExists)
                {
                    // Insert only once
                    var category = new Category { Name = "Electronics" };
                    context.Categories.Add(category);

                    var product = new Product
                    {
                        Name = "Laptop",
                        Stock = 20,
                        Category = category
                    };
                    context.Products.Add(product);

                    context.SaveChanges();
                    Console.WriteLine("Data saved successfully!");
                }
                else
                {
                    Console.WriteLine("Data already exists!");
                }

                // ✅ Show exactly what’s in the DB
                Console.WriteLine("\n=== Categories ===");
                foreach (var cat in context.Categories)
                {
                    Console.WriteLine($"Id: {cat.CategoryId}, Name: {cat.Name}");
                }

                Console.WriteLine("\n=== Products ===");
                foreach (var prod in context.Products.Include(p => p.Category))
                {
                    Console.WriteLine($"Id: {prod.ProductId}, Name: {prod.Name}, Stock: {prod.Stock}, Category: {prod.Category.Name}");
                }
            }
        }
    }
}
