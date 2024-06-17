using Microsoft.EntityFrameworkCore;
using my_first_api_net.Models.Collection;
using my_first_api_net.Models.User;

namespace my_first_api_net.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Task> Tasks { get; set; }
  }
}
