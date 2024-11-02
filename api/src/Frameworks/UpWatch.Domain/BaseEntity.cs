using System.ComponentModel.DataAnnotations;

namespace UpWatch.Domain;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
