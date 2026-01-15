using FluentValidation;
using InnoChess.Application.Auth;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Application.Services;
using InnoChess.Application.Validators;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using InnoChess.Infrastructure;
using InnoChess.Infrastructure.Repositories;
using InnoChess.Presentation.Endpoints;
using InnoChess.Presentation.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


services.AddScoped<IRepositoryBase<LocationEntity>, LocationRepository>();
services.AddScoped<IRepositoryBase<UserEntity>, UserRepository>();
services.AddScoped<IRepositoryBase<SessionEntity>, SessionRepository>();
services.AddScoped<IRepositoryBase<UserInSessionEntity>, UserInSessionRepository >();

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<ILocationRepository, LocationRepository>();
services.AddScoped<ISessionRepository, SessionRepository>();
services.AddScoped<IUserInSessionRepository, UserInSessionRepository>();

services.AddScoped<ILocationService, LocationService>();
services.AddScoped<ISessionService, SessionService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserInSessionService, UserInSessionService>();

services.AddScoped<UserService>();

services.AddScoped<IUserMapper, UserMapper>();
services.AddScoped<ILocationMapper, LocationMapper>();
services.AddScoped<ISessionMapper, SessionMapper>();
services.AddScoped<IUserInSessionMapper, UserInSessionMapper>();

services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IJwtProvider, JwtProvider>();

services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
services.AddApiAuthentication();

services.AddValidatorsFromAssemblyContaining<UserLoginRequestValidator>();
services.AddValidatorsFromAssemblyContaining<UserRegistrationRequestValidator>();
services.AddValidatorsFromAssemblyContaining<UserRequestValidator>();
services.AddValidatorsFromAssemblyContaining<LocationRequestValidator>();
services.AddValidatorsFromAssemblyContaining<SessionRequestValidator>();
services.AddValidatorsFromAssemblyContaining<UserInSessionRequestValidator>();

services.AddDbContext<InnoChessDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("InnoChessDbContext");
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapUserEndpoints();

app.MapControllers();

app.Run();
