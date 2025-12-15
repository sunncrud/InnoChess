using System.ComponentModel.DataAnnotations;

namespace InnoChess.Domain.Models;

public abstract class Entity<TKey>
{
    [Key]
    [Required]
    public TKey? Id { get; init; }
}