using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Settings;

namespace Play.Catalog.Service.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection InitMongo(this IServiceCollection services,WebApplicationBuilder builder)
        {
            services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

            return services;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services) where T : IEntity
        {

            services.AddSingleton<IRepository<T>, MongoRepository<T>>();

            return services;
        }
    }
}
