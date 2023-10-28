using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<Order>? Orders { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // NADAWANIE KLUCZY GŁÓWNYCH
        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .Property(o => o.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Customer>()
            .Property(c => c.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
            .Property(p => p.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => oi.Id);
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Id).ValueGeneratedOnAdd();
        // =====================================
        
        // NADAWANIE KLUCZY OBCYCH
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(c => c.CustomerId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Product)
            .WithMany()
            .HasForeignKey(o => o.ProductId);
        // =====================================
        
        // DODAWANIE DANYCH DO BAZY
        modelBuilder.Entity<Customer>()
            .HasData(new Customer()
            {
                Id = 1,
                Name = "Jan Kowalski"
            });
        
        modelBuilder.Entity<Customer>()
            .HasData(new Customer()
            {
                Id = 2,
                Name = "Adam Nowak"
            });
        
        modelBuilder.Entity<Product>()
            .HasData(new Product()
            {
                Id = 1,
                Name = "Książka",
                Price = 29.99m
            });
        
        modelBuilder.Entity<Product>()
            .HasData(new Product()
            {
                Id = 2,
                Name = "Długopis",
                Price = 2.99m
            });
        
        modelBuilder.Entity<Order>()
            .HasData(new Order()
            {
                Id = 1,
                OrderNumber = "FV 1/2021",
                OrderDate = new DateTime(2023, 10, 29),
                CustomerId = 1,
            });
        
        modelBuilder.Entity<Order>()
            .HasData(new Order()
            {
                Id = 2,
                OrderNumber = "FV 2/2021",
                OrderDate = new DateTime(2023, 10, 29),
                CustomerId = 1,
            });
        
        modelBuilder.Entity<Order>()
            .HasData(new Order()
            {
                Id = 3,
                OrderNumber = "FV 3/2021",
                OrderDate = new DateTime(2023, 10, 29),
                CustomerId = 2,
            });

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem()
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 2
            },
            new OrderItem()
            {
                Id = 2,
                OrderId = 1,
                ProductId = 2,
                Quantity = 5
            },
            new OrderItem()
            {
                Id = 3,
                OrderId = 2,
                ProductId = 1,
                Quantity = 1
            },
            new OrderItem()
            {
                Id = 4,
                OrderId = 2,
                ProductId = 2,
                Quantity = 1
            },
            new OrderItem()
            {
                Id = 5,
                OrderId = 3,
                ProductId = 1,
                Quantity = 1
            },
            new OrderItem()
            {
                Id = 6,
                OrderId = 3,
                ProductId = 2,
                Quantity = 1
            }
        );

    }
}