using Microsoft.EntityFrameworkCore;
using CornerStore.Models;
using System.Security.Cryptography.X509Certificates;
public class CornerStoreDbContext : DbContext
{
    public DbSet<Cashier> Cashiers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public CornerStoreDbContext(DbContextOptions<CornerStoreDbContext> context) : base(context)
    {

    }

    //allows us to configure the schema when migrating as well as seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cashier>().HasData(new Cashier[]
        {
            new Cashier {Id = 1, FirstName = "Carl", LastName = "Henley"},
            new Cashier {Id = 2, FirstName = "Burt", LastName = "Lentil"},
            new Cashier {Id = 3, FirstName = "Alice", LastName = "Carrot"}
        });
        modelBuilder.Entity<Product>().HasData
        (new Product[]
        {
            new Product {Id = 1, ProductName = "Crawtator", Price = 3.99M, Brand = "Zapps", CategoryId = 1},
            new Product {Id = 2, ProductName = "Barbecue Chips", Price = 3.49M, Brand = "Lays", CategoryId = 1},
            new Product {Id = 3, ProductName = "Zero Ultra", Price = 3.70M, Brand = "Monster", CategoryId = 2},
            new Product {Id = 4, ProductName = "Crazy Yum", Price = 2.99M, Brand = "High Energy", CategoryId = 2}
        });
        modelBuilder.Entity<Category>().HasData
        (new Category[]
        {
            new Category {Id = 1, CategoryName = "Chips"},
            new Category {Id = 2, CategoryName = "Energy Drink"}
        });
        modelBuilder.Entity<Order>().HasData
        (new Order[]
        {
            new Order {Id = 1, CashierId = 2, PaidOnDate = new DateTime(2026, 10, 22, 9, 30, 0)},
            new Order {Id = 2, CashierId = 1, PaidOnDate = new DateTime(2026, 10, 22, 9, 39, 0)},
            new Order {Id = 3, CashierId = 3, PaidOnDate = new DateTime(2026, 10, 24, 9, 45, 0)}
        });

        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new OrderProduct {Id = 1, ProductId = 1, OrderId = 1, Quantity = 1},
            new OrderProduct {Id = 2, ProductId = 3, OrderId = 1, Quantity = 2},
            new OrderProduct {Id = 3, ProductId = 4, OrderId = 2, Quantity = 4},
            new OrderProduct {Id = 4, ProductId = 2, OrderId = 3, Quantity = 2},
            new OrderProduct {Id = 5, ProductId = 4, OrderId = 3, Quantity = 1}

        });
    }
}