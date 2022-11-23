using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Settings;

namespace Play.Catalog.Service.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection InitMongo(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var mongoDBSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

                var mongoClient = new MongoClient(mongoDBSettings.ConnectionString);
                return mongoClient.GetDatabase(mongoDBSettings.DatabaseName);
            });

            return services;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services) where T : IEntity
        {

            services.AddSingleton<IRepository<T>, MongoRepository<T>>();

            return services;
        }
    }
}
