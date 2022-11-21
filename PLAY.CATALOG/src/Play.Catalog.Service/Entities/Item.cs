using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.utils;

namespace Play.Catalog.Service.Entities;

[BsonCollection("items")]
public class Item : IEntity
{

    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTimeOffset CreateDate { get; set; }

}

