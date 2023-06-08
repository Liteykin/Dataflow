using Microsoft.EntityFrameworkCore;
using Dataflow.Models;

namespace Dataflow.Models
{
    public class DataflowContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DataflowContext GetDatabase(bool deleteDatabase = false)
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite("Data Source=Dataflow.db")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var db = new DataflowContext(options);
            if (deleteDatabase)
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            return db;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Dataflow.db");
            }
        }

        public DataflowContext(DbContextOptions opt) : base(opt) { }

        public DataflowContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ContactList)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReminderList)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.ToDoList)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }


    public void Seed()
    {
        var faker = new Bogus.Faker();

        // Seed Users
        var users = new Bogus.Faker<User>()
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
            .RuleFor(u => u.CreatedAt, f => f.Date.Past(2))
            .RuleFor(u => u.IsOnline, f => f.Random.Bool())
            .RuleFor(u => u.ProfilePicUrl, f => f.Internet.Avatar())
            .Generate(10);

        Users.AddRange(users);
        SaveChanges();

        // Seed ToDos
        var toDos = new Bogus.Faker<ToDo>()
            .RuleFor(t => t.UserId, f => f.PickRandom(users).Id)
            .RuleFor(t => t.Title, f => f.Lorem.Sentence())
            .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
            .RuleFor(t => t.DueDate, f => f.Date.Future(1))
            .RuleFor(t => t.IsCompleted, f => f.Random.Bool())
            .RuleFor(t => t.CreatedAt, f => f.Date.Past(1))
            .RuleFor(t => t.UpdatedAt, f => f.Date.Recent())
            .Generate(50);

        ToDos.AddRange(toDos);
        SaveChanges();

        // Seed Reminders
        var reminders = new Bogus.Faker<Reminder>()
            .RuleFor(r => r.UserId, f => f.PickRandom(users).Id)
            .RuleFor(r => r.Name, f => f.Lorem.Word())
            .RuleFor(r => r.Description, f => f.Lorem.Sentence())
            .RuleFor(r => r.ReminderTime, f => f.Date.Future(1))
            .Generate(50);

        Reminders.AddRange(reminders);
        SaveChanges();

        // Seed Events
        var events = new Bogus.Faker<Event>()
            .RuleFor(e => e.UserId, f => f.PickRandom(users).Id)
            .RuleFor(e => e.Title, f => f.Lorem.Sentence())
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Start, f => f.Date.Future(1))
            .RuleFor(e => e.End, f => f.Date.Future(2))
            .RuleFor(e => e.IsAllDay, f => f.Random.Bool())
            .RuleFor(e => e.Location, f => f.Address.FullAddress())
            .RuleFor(e => e.CreatedAt, f => f.Date.Past(1))
            .RuleFor(e => e.UpdatedAt, f => f.Date.Recent())
            .Generate(50);

        Events.AddRange(events);
        SaveChanges();

        // Seed Contacts
        var contacts = new Bogus.Faker<Contact>()
            .RuleFor(c => c.UserId, f => f.PickRandom(users).Id)
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c =>c.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Address, f => f.Address.FullAddress())
            .Generate(50);

        Contacts.AddRange(contacts);
        SaveChanges();
    }
    }
}
