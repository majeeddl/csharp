using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Play.Catalog.Service.Repositories;
using Play.Common.Settings;

namespace Play.Common.MongoDB
{
    public static class Extensions
    {
        public static IServiceCollection InitMongo(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {

                var configuration = serviceProvider.GetService<IConfiguration>();
                var mongoDbSettings = configuration?.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

                var mongoClient = new MongoClient(mongoDbSettings?.ConnectionString);

                return mongoClient.GetDatabase(mongoDbSettings?.DatabaseName);
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
