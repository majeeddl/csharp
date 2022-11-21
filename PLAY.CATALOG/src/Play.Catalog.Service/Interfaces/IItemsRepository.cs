using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Interfaces;

public interface IItemsRepository
{
    Task<IReadOnlyCollection<Item>> GetAllAsync();
    Task<Item> GetAsync(Guid id);
    Task CreatAsync(Item entity);
    Task UpdateAsync(Item entity);
    Task DeleteAsync(Guid id);
}