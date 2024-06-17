using my_first_api_net.Models.User;

namespace my_first_api_net.Interfaces
{
  public interface IUserService
  {
    Task<User?> GetUserById(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task<User?> UpdateUserAsync(Guid id, UpdatedUser updatedUser);
    Task<bool> DeleteUserAsync(Guid id);
  }
}