namespace Play.Common.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; } = null!;

        public string Port { get; init; } = null!;

        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        //public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
