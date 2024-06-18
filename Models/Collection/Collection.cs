using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_first_api_net.Models.Collection
{
  [Table("collections")]
  public class Collection
  {
    [Key]
    [Column("id")]
    public Guid Id { get; } = Guid.NewGuid();

    [Column("name")]
    public required string Name { get; set; }

    [Column("banner")]
    public required string Banner { get; set; }

    [Column("user_id")]
    public required Guid UserId { get; set; }
  }

}