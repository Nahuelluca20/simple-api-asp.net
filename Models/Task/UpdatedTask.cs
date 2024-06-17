namespace my_first_api_net.Models.Task
{
  public class UpdatedTask
  {
    public string? Title { get; set; }
    public string? Description { get; set; }

    public DateOnly? Date { get; set; }
    public string? Priority { get; set; }
    public DateOnly? DeadLine { get; set; }
    public Guid? CollectionId { get; set; }
    public Guid? UserId { get; set; }

  }
}