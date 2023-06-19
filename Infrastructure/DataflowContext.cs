using Bogus;
using Dataflow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public DbSet<Category> Categories { get; set; }

        public DataflowContext(DbContextOptions<DataflowContext> options)
            : base(options) { }

        public void SeedData()
        {
            SeedUsers();
            SeedContacts();
            SeedCategories();
            SeedProducts();
        }

        private void SeedUsers()
        {
            if (!Users.Any())
            {
                var fakeUser = new Faker<User>()
                    .RuleFor(u => u.Username, f => f.Internet.UserName())
                    .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                    .RuleFor(u => u.LastName, f => f.Person.LastName)
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Password, f => f.Internet.Password())
                    .RuleFor(u => u.RegistrationDate, f => f.Date.Past());

                var users = fakeUser.Generate(10);
                Users.AddRange(users);
                SaveChanges();
            }
        }

        private void SeedContacts()
        {
            if (!Contacts.Any())
            {
                var users = Users.ToList();
                var fakeContact = new Faker<Contact>()
                    .RuleFor(c => c.UserId, f => f.PickRandom(users).Id)
                    .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                    .RuleFor(c => c.LastName, f => f.Person.LastName)
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress());

                var contacts = fakeContact.Generate(10);
                Contacts.AddRange(contacts);
                SaveChanges();
            }
        }

        private void SeedCategories()
        {
            if (!Categories.Any())
            {
                var fakeCategory = new Faker<Category>()
                    .RuleFor(c => c.CategoryName, f => f.Commerce.ProductName())
                    .RuleFor(c => c.Description, f => f.Lorem.Sentence());

                var categories = fakeCategory.Generate(5);
                Categories.AddRange(categories);
                SaveChanges();
            }
        }


        private void SeedProducts()
        {
            if (!Products.Any())
            {
                var categories = Categories.ToList();
                var fakeProduct = new Faker<Product>()
                    .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Picture, f => f.Internet.Avatar())
                    .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                    .RuleFor(p => p.InStock, f => f.Random.Int(0, 100))
                    .RuleFor(p => p.Price, f => f.Random.Decimal(1.0m, 100.0m))
                    .RuleFor(p => p.Rating, f => f.Random.Decimal(1.0m, 5.0m))
                    .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id);

                var products = fakeProduct.Generate(10);
                Products.AddRange(products);
                SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            // Relationship: Order -> OrderProduct (One to Many)
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);

            // Relationship: Product -> Category (Many to One)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Composite Primary Key for OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            // Configure Category entity
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName) // Update the property name to CategoryName
                .IsRequired();

        }

        public void ShowData()
        {
            // Retrieve data using LINQ queries
            var users = Users.ToList();
            var contacts = Contacts.ToList();
            var products = Products.ToList();
            var orders = Orders.ToList();
            var orderProducts = OrderProducts.ToList();
            var todos = Todos.ToList();
            var categories = Categories.ToList();

            // Display the retrieved data
            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.Id}, Username: {user.Username}, Email: {user.Email}");
            }

            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Contact ID: {contact.Id}, Name: {contact.FirstName} {contact.LastName}, Email: {contact.Email}");
            }

            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.ProductName}, Price: {product.Price}");
            }

            Console.WriteLine("Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Customer: {order.CustomerName}, Total Amount: {order.TotalAmount}");
            }

            Console.WriteLine("Order Products:");
            foreach (var orderProduct in orderProducts)
            {
                Console.WriteLine($"Order ID: {orderProduct.OrderId}, Product ID: {orderProduct.ProductId}, Quantity: {orderProduct.Quantity}");
            }

            Console.WriteLine("Todos:");
            foreach (var todo in todos)
            {
                Console.WriteLine($"Todo ID: {todo.Id}, Title: {todo.Title}, Description: {todo.Description}");
            }

            Console.WriteLine("Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"Category ID: {category.Id}, Name: {category.CategoryName}, Description: {category.Description}");
            }

        }
    }
}
