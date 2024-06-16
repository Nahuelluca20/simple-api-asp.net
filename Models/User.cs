public class User
{
  public Guid Id { get; } = Guid.NewGuid();
  public required string Name { get; set; }
  public required string UserName { get; set; }
  public int age { get; set; }
  public required string email { get; set; }
  public required string password { get; set; }

}


public class UpdatedUser
{
  public string? Name { get; set; }
  public string? UserName { get; set; }
  public int? age { get; set; }
  public string? email { get; set; }
  public string? password { get; set; }

}