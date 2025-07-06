using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RetailStore
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RetailStoreDb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Creating database...");
                context.Database.EnsureCreated();

                var category = new Category { Name = "Electronics" };
                context.Categories.Add(category);

                var product = new Product { Name = "Laptop", Price = 999.99M, Category = category };
                context.Products.Add(product);

                context.SaveChanges();

                Console.WriteLine("Data saved!");
            }
        }
    }
}
