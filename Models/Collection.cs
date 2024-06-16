public class Collection
{
  public Guid Id { get; } = Guid.NewGuid();
  public required string name { get; set; }
  public required string banner { get; set; }
  public required Guid UserId { get; set; }
}

public class UpdatedCollection
{
  public string? name { get; set; }

  public string? banner { get; set; }

  public Guid UserId { get; set; }
}