
using Microsoft.EntityFrameworkCore;
using my_first_api_net.Data;
using my_first_api_net.Interfaces;
using my_first_api_net.Models.User;

namespace my_first_api_net.Services
{
  public class UserService(ApplicationDbContext context) : IUserService
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
      return await _context.users.ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
      return await _context.users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
      var entityEntry = await _context.users.AddAsync(user);
      await _context.SaveChangesAsync();
      return entityEntry.Entity;
    }

    public async Task<User?> UpdateUserAsync(Guid id, UpdatedUser updatedUser)
    {
      var user = await _context.users.FindAsync(id);

      if (user is null)
      {
        return null;
      }

      user.Name = updatedUser.Name ?? user.Name;
      user.UserName = updatedUser.UserName ?? user.UserName;
      user.Age = updatedUser.Age ?? user.Age;
      user.Email = updatedUser.Email ?? user.Email;
      user.Password = updatedUser.Password ?? user.Password;

      await _context.SaveChangesAsync();

      return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
      var user = await _context.users.FindAsync(id);

      if (user == null)
      {
        return false;
      }

      _context.users.Remove(user);
      await _context.SaveChangesAsync();

      return true;
    }

  }
}