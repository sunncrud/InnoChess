using System.ComponentModel.DataAnnotations;

namespace InnoChess.Domain.Primitives;

public interface IEntity<out TKey>
{
    [Key] TKey? Id { get; }
}