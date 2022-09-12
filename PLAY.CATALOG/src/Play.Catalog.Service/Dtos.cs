
namespace Play.Catalog.Service.Dtos;

public record ItemDto(Guid Id, string Name, string description, decimal Price, DateTimeOffset createDate);
public record CreateItemDto(string name, string Description, decimal Price);
public record UpdateItemDto(string name, string Description, decimal Price);
