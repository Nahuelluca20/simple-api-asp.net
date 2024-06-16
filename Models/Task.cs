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

public class GetTask
{
  public Guid Id { get; } = Guid.NewGuid();
  public string? Description { get; set; }

  public DateOnly? Date { get; set; }
  public string? Priority { get; set; }
  public DateOnly? DeadLine { get; set; }

}

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