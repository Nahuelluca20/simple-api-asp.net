namespace my_first_api_net.Models.Task
{
  public class GetTask
  {
    public Guid Id { get; } = Guid.NewGuid();
    public string? Description { get; set; }

    public DateOnly? Date { get; set; }
    public string? Priority { get; set; }
    public DateOnly? DeadLine { get; set; }

  }
}