using FlexHub.Data.Entities;
using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Utilities;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace FlexHub.Services.IntegrationTests.DataAccess;

[Collection("Database collection")]
public class UserRepositoryTests
{
    private readonly LocalDbInitializerFixture _fixture;
    private readonly ILogger<UserRepository> _logger;

    public UserRepositoryTests(ITestOutputHelper testOutputHelper, LocalDbInitializerFixture fixture)
    {
        _fixture = fixture;
        _logger = XUnitLogger.CreateLogger<UserRepository>(testOutputHelper);
    }

    [Fact]
    public async Task GetLastAddedContacts_FetchLastAddedContacts()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);
        var userRepository = new UserRepository(_logger, dbContext);

        var userObjectId = SampleData.UserObjectIds.Last();

        // Testing
        var contactUsers = await userRepository.GetLastAddedContacts(userObjectId, 10);

        foreach (var contactUser in contactUsers)
        {
            _logger.LogInformation(contactUser.ObjectId);
        }

        // Verification
        Assert.True(contactUsers.Any());
    }

    [Fact]
    public async Task GetUserContactsFilteredByName_FetchUserContactsFilteredByName()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);
        var userRepository = new UserRepository(_logger, dbContext);

        var userObjectId = SampleData.UserObjectIds.Last();

        // Testing
        var contactsByName = await userRepository.GetUserContactsFilteredByName(userObjectId, "Rickie");

        foreach (var user in contactsByName)
        {
            _logger.LogInformation(user.GivenName);
        }
        
        // Verification
        Assert.True(contactsByName.Any());
    }
}
