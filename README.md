# Simple API with Collections, User and Tasks models
In this project we have 3 entities
User:
```csharp
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
```

Collection:
```csharp
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
```

Task:
```csharp
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
```



 
