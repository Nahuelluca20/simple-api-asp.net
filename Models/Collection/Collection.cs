namespace my_first_api_net.Models.Collection
{
  public class Collection
  {
    public Guid Id { get; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Banner { get; set; }
    public required Guid UserId { get; set; }
  }

}