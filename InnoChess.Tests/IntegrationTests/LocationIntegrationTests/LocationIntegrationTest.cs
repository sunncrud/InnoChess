using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions; 
using InnoChess.Application.DTO.LocationDto;
using InnoChess.Domain.Models; 
using InnoChess.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace InnoChess.Tests.IntegrationTests.LocationIntegrationTests;

public class LocationIntegrationTest : IDisposable
{
    private readonly IntegrationTestWebAppFactory _app;
    private readonly HttpClient _client;
    private readonly IServiceScope _scope;
    private readonly InnoChessDbContext _dbContext;

    public LocationIntegrationTest()
    {
        _app = new IntegrationTestWebAppFactory();
        _client = _app.CreateClient();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("TestScheme");

        _scope = _app.Services.CreateScope();
        _dbContext = _scope.ServiceProvider.GetRequiredService<InnoChessDbContext>();
        _dbContext.Database.EnsureCreated(); 
    }
    private void SeedData(params LocationEntity[] entities)
    {
        foreach (var e in entities)
        {
            _dbContext.Set<LocationEntity>().Add(e);
        }
    }

    private LocationEntity CreateLocation(string name, string description)
    {
        return new LocationEntity
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };
    }
    
    [Fact]
    public async Task SearchLocationByName_Should_ReturnLocation_WhenItExists()
    {
        // Arrange
        SeedData(
            CreateLocation("something", "A test location"),
            CreateLocation("Winterfell", "The North")
        );
        await _dbContext.SaveChangesAsync();

        // Act
        var response = await _client.GetAsync("/api/location/by-name?name=something");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var location = await response.Content.ReadFromJsonAsync<LocationResponse>();
        location.Should().NotBeNull();
        location!.Name.Should().Be("something"); 
    }
    
    [Fact]
    public async Task SearchLocationByName_Should_ReturnNotFound_WhenItDoesNotExist()
    {
        // Arrange
        SeedData(
            CreateLocation("Winterfell", "The North"),
            CreateLocation("Central Park", "A large park in NY")
        );
        await _dbContext.SaveChangesAsync();

        // Act 
        var response = await _client.GetAsync("/api/location/by-name?name=NonExistentName");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task SearchLocationByDescription_Should_ReturnLocation_WhenItExists()
    {
        // Arrange
        SeedData(
            CreateLocation("Central Park", "test location"), 
            CreateLocation("Winterfell", "The North")
        );
        await _dbContext.SaveChangesAsync();

        // Act 
        var response = await _client.GetAsync("/api/location/by-description?description=test%20location");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var location = await response.Content.ReadFromJsonAsync<LocationResponse>();
        location.Should().NotBeNull();
        location!.Description.Should().Be("test location");
    }
    
    [Fact]
    public async Task SearchLocationByDescription_Should_ReturnNotFound_WhenItDoesNotExist()
    {
        // Arrange 
        SeedData(
            CreateLocation("Winterfell", "The North"),
            CreateLocation("Central Park", "A large park in NY")
        );
        await _dbContext.SaveChangesAsync();

        // Act
        var response = await _client.GetAsync("/api/location/by-description?description=something");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
        _scope.Dispose();
        _client.Dispose();
        _app.Dispose();
    }
}