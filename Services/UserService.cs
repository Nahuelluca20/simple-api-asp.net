
using my_first_api_net.Data;
using my_first_api_net.Interfaces;
using my_first_api_net.Models.User;

namespace my_first_api_net.Services
{
  public class UserService(ApplicationDbContext context) : IUserService
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<User?> GetUserById(Guid id)
    {
      return await _context.users.FindAsync(id);
    }

    public Task<User> CreateUserAsync()
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task<User?> UpdateUserAsync(Guid id, UpdatedUser updatedUser)
    {
      throw new NotImplementedException();
    }
  }
}