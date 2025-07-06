﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    public class Product
    {
        public int ProductId { get; set; }  
        public string Name { get; set; } = null!;
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }

    public class Category
    {
        public int CategoryId { get; set; }  
        public string Name { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class RetailContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RetailInventoryDB;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var db = new RetailContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };
            var clothing = new Category { Name = "Clothing" };

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Stock = 10, Category = electronics },
                new Product { Name = "Smartphone", Stock = 25, Category = electronics },
                new Product { Name = "Headphones", Stock = 50, Category = electronics },
                new Product { Name = "Apple", Stock = 100, Category = groceries },
                new Product { Name = "Milk", Stock = 60, Category = groceries },
                new Product { Name = "Bread", Stock = 40, Category = groceries },
                new Product { Name = "T-Shirt", Stock = 35, Category = clothing },
                new Product { Name = "Jeans", Stock = 20, Category = clothing },
                new Product { Name = "Jacket", Stock = 15, Category = clothing }
            };

            db.Categories.AddRange(electronics, groceries, clothing);
            db.Products.AddRange(products);
            db.SaveChanges();

            var productsWithCategory = db.Products
                .Include(p => p.Category)
                .ToList();

            foreach (var p in productsWithCategory)
            {
                Console.WriteLine($"Product: {p.Name}, Stock: {p.Stock}, Category: {p.Category.Name}");
            }
        }
    }
}
