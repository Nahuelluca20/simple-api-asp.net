using Microsoft.EntityFrameworkCore;
using my_first_api_net.Models.User;
// using MyFirstApiNet.Models;}

namespace my_first_api_net.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<User> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
          .HasKey(c => c.Id);
    }

    // public DbSet<Task> Tasks { get; set; }
  }
}
