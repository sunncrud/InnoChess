using System.ComponentModel.DataAnnotations;

namespace InnoChess.Domain.Primitives;

public interface IEntity
{
    [Key] Guid Id { get; }
}