using my_first_api_net.Data;

namespace my_first_api_net.Services
{
  public class UserService(ApplicationDbContext context)
  {
    private readonly ApplicationDbContext _context = context;


  }
}