using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public void Print()
    {
        Console.WriteLine($"Found: {ProductName} (ID: {ProductId}, Category: {Category})");
    }
}

public class Program
{
    public static void Main()
    {
        Product[] products = new Product[]
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(205, "Shoes", "Fashion"),
            new Product(150, "Watch", "Accessories"),
            new Product(300, "Phone", "Electronics"),
            new Product(450, "Tablet", "Electronics"),
            new Product(500, "Backpack", "Fashion"),
            new Product(600, "Camera", "Electronics"),
            new Product(700, "Headphones", "Electronics"),
            new Product(800, "Book", "Books"),
            new Product(900, "Sunglasses", "Accessories"),
            new Product(1000, "Jacket", "Fashion"),
            new Product(1100, "Mouse", "Electronics"),
            new Product(1200, "Keyboard", "Electronics"),
            new Product(1300, "Charger", "Electronics"),
            new Product(1400, "Desk Lamp", "Home"),
            new Product(1500, "Coffee Mug", "Home")
        };

        Array.Sort(products, (p1, p2) => p1.ProductId.CompareTo(p2.ProductId));

        Console.Write("Enter Product ID to search: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int searchId))
        {
            Console.WriteLine("\nLinear Search:");
            Product foundLinear = LinearSearch(products, searchId);
            if (foundLinear != null) foundLinear.Print();
            else Console.WriteLine("Product not found");

            Console.WriteLine("\nBinary Search:");
            Product foundBinary = BinarySearch(products, searchId);
            if (foundBinary != null) foundBinary.Print();
            else Console.WriteLine("Product not found");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric Product ID.");
        }
    }

    public static Product LinearSearch(Product[] products, int id)
    {
        foreach (var p in products)
        {
            if (p.ProductId == id)
                return p;
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, int id)
    {
        int left = 0, right = products.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (products[mid].ProductId == id)
                return products[mid];
            else if (products[mid].ProductId < id)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }
}
