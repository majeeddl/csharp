namespace Play.Catalog.Service.Interfaces;

public interface IItem
{
    Guid Id { get; set; }
    string? Name { get; set; }
    string? Description { get; set; }
    decimal Price { get; set; }
    DateTimeOffset CreateDate { get; set; }
}