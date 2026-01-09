using System.ComponentModel.DataAnnotations;

namespace InnoChess.Domain.Models;

public abstract class Entity<TKey>
{
    [Key] public TKey? Id { get; init; }
}