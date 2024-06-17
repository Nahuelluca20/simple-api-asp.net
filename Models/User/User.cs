namespace my_first_api_net.Models.User
{
  public class User
  {
    public Guid Id { get; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string UserName { get; set; }
    public int Age { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

  }

}