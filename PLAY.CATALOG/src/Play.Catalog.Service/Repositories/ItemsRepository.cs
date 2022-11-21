using System.Runtime.CompilerServices;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories;


public class ItemsRepository
{

    private const string CollectionName = "items";

    private readonly IMongoCollection<Item> _dbCollection;

    private readonly FilterDefinitionBuilder<Item> _filterDefinitionBuilder = Builders<Item>.Filter;

    public ItemsRepository()
    {
        var mongoClient = new MongoClient("mongodb://locahost:27017");

        var database = mongoClient.GetDatabase("Catalog");

        _dbCollection = database.GetCollection<Item>(CollectionName);
    }

    public async Task<IReadOnlyCollection<Item>> GetAllAsync()
    {
        return await _dbCollection.Find(_filterDefinitionBuilder.Empty).ToListAsync();
    }


    public async Task<Item> GetAsync(Guid id)
    {
        var filter = _filterDefinitionBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task CreatAsync(Item entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Item entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var filter = _filterDefinitionBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);

        await _dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = _filterDefinitionBuilder.Eq(entity => entity.Id, id);
        await _dbCollection.DeleteOneAsync(filter);
    }
}

