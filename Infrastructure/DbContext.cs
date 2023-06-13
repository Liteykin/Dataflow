using Microsoft.EntityFrameworkCore;
using Dataflow.Models;
using System;

namespace Dataflow.Data
{
    public class DataflowContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        public DataflowContext(DbContextOptions<DataflowContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship: User -> Contact (One to Many)
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User)
                .WithMany(u => u.ContactList)
                .HasForeignKey(c => c.UserId);

            // Relationship: User -> Todo (One to Many)
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.User)
                .WithMany(u => u.ToDoList)
                .HasForeignKey(t => t.UserId);

            // Relationship: Order -> OrderProduct (One to Many)
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            // Relationship: Product -> OrderProduct (One to Many)
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            // Seed Data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "johndoe", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "password123", RegistrationDate = DateTime.Now });

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890", Address = "123 Main St" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "Sample Product", Picture = "picture.jpg", Description = "This is a sample product.", InStock = 10, Price = 9.99m, Rating = 4.5m });

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerName = "John Doe", OrderDate = DateTime.Now, TotalAmount = 9.99m, IsShipped = false });

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct { OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 9.99m });

            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id = 1, UserId = 1, Title = "Sample Todo", Description = "This is a sample todo item.", DueDate = DateTime.Now.AddDays(7), IsCompleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        }
    }
}
