using System.ComponentModel.DataAnnotations.Schema;

namespace my_first_api_net.Models.Task
{
  [Table("tasks")]
  public class Task
  {
    [Column("id")]
    public Guid Id { get; } = Guid.NewGuid();

    [Column("title")]
    public required string Title { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("date")]
    public required DateOnly Date { get; set; }
    [Column("priority")]
    public required string Priority { get; set; }
    [Column("deadline")]
    public required DateOnly DeadLine { get; set; }
    [Column("collection_id")]
    public required Guid CollectionId { get; set; }
    [Column("user_id")]
    public required Guid UserId { get; set; }

  }

}