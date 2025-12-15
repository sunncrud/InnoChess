using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Application.Services;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using InnoChess.Infrastructure;
using InnoChess.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//var connectionString =
    //"Server=innochessdb,1433;Database=InnoChess;User Id=sa;Password=StrongPassword!23;Encrypt=True;TrustServerCertificate=True;";
;
//var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryBase<LocationEntity, Guid>, LocationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ICrudService<LocationRequest, LocationResponse, Guid>, 
    CrudService<LocationRequest, LocationResponse,LocationEntity,ILocationMapper,Guid>>();
builder.Services.AddScoped<ILocationMapper, LocationMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<ISessionMapper, SessionMapper>();

builder.Services.AddDbContext<InnoChessDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(InnoChessDbContext)));
    //options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InnoChessDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
