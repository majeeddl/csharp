namespace Play.Common;

public interface IEntity
{
    Guid Id { get; set; }

    DateTime CreatedAt { get; set; }

    DateTime UpdatedAt { get; set; }
}