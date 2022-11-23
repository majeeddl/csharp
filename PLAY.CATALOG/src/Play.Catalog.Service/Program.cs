using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Settings;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();


// Add services to the container.
var mongoSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
var m = mongoSettings;


//var confOption = builder.Configuration.GetSection("MongoDbSettings");
//services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

//services.AddSingleton<IRepository<Item>, MongoRepository<Item>>();



services.InitMongo();

services.AddMongoRepository<Item>();

services.AddControllers((options) =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
