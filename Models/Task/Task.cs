namespace my_first_api_net.Models.Task
{
  public class Task
  {
    public Guid Id { get; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Description { get; set; }

    public required DateOnly Date { get; set; }
    public required string Priority { get; set; }
    public required DateOnly DeadLine { get; set; }
    public required Guid CollectionId { get; set; }
    public required Guid UserId { get; set; }

  }

}