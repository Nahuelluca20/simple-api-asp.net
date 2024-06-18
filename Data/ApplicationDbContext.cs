using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using my_first_api_net.Models.Collection;
using my_first_api_net.Models.User;

namespace my_first_api_net.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Collection> Collections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
          .HasKey(c => c.Id);

      modelBuilder.Entity<Collection>()
        .HasKey(c => c.Id);
    }

  }
}
