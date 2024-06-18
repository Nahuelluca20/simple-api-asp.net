
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_first_api_net.Models.User
{
  [Table("users")]
  public class User
  {
    [Key]
    [Column("id")]
    public Guid Id { get; } = Guid.NewGuid();

    [Column("name")]
    public required string Name { get; set; }

    [Column("username")]
    public required string UserName { get; set; }

    [Column("age")]
    public int Age { get; set; }

    [Column("email")]
    public required string Email { get; set; }


    [Column("password")]
    public required string Password { get; set; }
  }

}