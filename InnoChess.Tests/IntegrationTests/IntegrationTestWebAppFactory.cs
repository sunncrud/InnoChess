using System.Data.Common; 
using Microsoft.Data.Sqlite; 
using InnoChess.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace InnoChess.Tests.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureTestServices(services =>
        {
            var optionsDescriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<InnoChessDbContext>));
            if (optionsDescriptor != null) services.Remove(optionsDescriptor);

            var configDescriptor = services.SingleOrDefault(s => s.ServiceType == typeof(IDbContextOptionsConfiguration<InnoChessDbContext>));
            if (configDescriptor != null) services.Remove(configDescriptor);
            
            services.AddSingleton<DbConnection>(container =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                return connection;
            });

            services.AddDbContext<InnoChessDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "TestScheme";
                options.DefaultChallengeScheme = "TestScheme";
            })
            .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("TestScheme", options => { });
        });
    }
}