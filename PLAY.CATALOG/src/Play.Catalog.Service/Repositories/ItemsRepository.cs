using System.Runtime.CompilerServices;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories;


public class ItemsRepository
{

    private const string collectionName = "items";

    private readonly IMongoCollection<Item> dbCollection;

    private readonly FilterDefinitionBuilder<Item> filterDefinitionBuilder = Builders<Item>.Filter;

    public ItemsRepository()
    {
        var mongoClient = new MongoClient("mongodb://locahost:27017");

        var database = mongoClient.GetDatabase("Catalog");

        dbCollection = database.GetCollection<Item>(collectionName);
    }

    public async Task<IReadOnlyCollection<Item>> GetAllAsync()
    {
        return await dbCollection.Find(filterDefinitionBuilder.Empty).ToListAsync();
    }


    public async Task<Item> GetAsync(Guid Id)
    {
        FilterDefinition<Item> filter = filterDefinitionBuilder.Eq(entity => entity.Id, Id);
        return await dbCollection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task CreatAsync(Item entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Item entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        FilterDefinition<Item> filter = filterDefinitionBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);

        await dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(Guid Id)
    {
        FilterDefinition<Item> filter = filterDefinitionBuilder.Eq(entity => entity.Id, Id);
        await dbCollection.DeleteOneAsync(filter);
    }
}

