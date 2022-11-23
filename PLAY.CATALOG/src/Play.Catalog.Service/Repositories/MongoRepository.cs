using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Settings;
using Play.Catalog.Service.Utils;

namespace Play.Catalog.Service.Repositories;


public class MongoRepository<T> : IRepository<T> where T : IEntity
{

    private readonly IMongoCollection<T> _dbCollection;

    private readonly FilterDefinitionBuilder<T> _filterDefinitionBuilder = Builders<T>.Filter;

    private protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault())?.CollectionName;
    }

    public MongoRepository(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);

        var database = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

        var collectionNameWithAttribute = GetCollectionName(typeof(T));

        var collectionName = typeof(T).Name.ToLowerInvariant() + "s";

        _dbCollection = database.GetCollection<T>(collectionName);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _dbCollection.Find(_filterDefinitionBuilder.Empty).ToListAsync();
    }


    public async Task<T> GetAsync(Guid id)
    {
        var filter = _filterDefinitionBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task CreateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(T entity)
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

