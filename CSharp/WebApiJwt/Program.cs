using WebApiJwt.Helpers;
using WebApiJwt.Interfaces;
using WebApiJwt.Services;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    //Configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    //
    services.AddScoped<IUserService, UserService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}
// Add services to the container


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    // app.UseHttpsRedirection();

    app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

    // app.UseAuthorization();
    //Custom jwt authentication
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run();