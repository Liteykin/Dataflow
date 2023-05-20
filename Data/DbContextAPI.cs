using Dataflow.Models;
using Microsoft.EntityFrameworkCore;

namespace Dataflow.Data;

public class DbContextAPI : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbContextAPI(DbContextOptions<DbContextAPI> options) : base(options)
    {
    }
}