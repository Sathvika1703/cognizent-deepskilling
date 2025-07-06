using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public Category Category { get; set; } = null!;
}

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailStoreDb;Trusted_Connection=True;");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("Applying migrations...");
        await context.Database.MigrateAsync();

        if (!await context.Products.AnyAsync())
        {
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            await context.Products.AddRangeAsync(product1, product2);

            await context.SaveChangesAsync();
        }

        var products = await context.Products
            .Include(p => p.Category)
            .ToListAsync();

        Console.WriteLine("\nProducts in database:");
        foreach (var p in products)
        {
            Console.WriteLine($"- {p.Name} | Price: {p.Price} | Category: {p.Category.Name}");
        }

        Console.WriteLine("\nData inserted successfully!");
    }
}
