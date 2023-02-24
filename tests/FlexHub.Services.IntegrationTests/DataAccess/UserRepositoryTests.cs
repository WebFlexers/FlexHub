using FlexHub.Data.Entities;
using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Utilities;
using Microsoft.Extensions.Logging;
using System.Linq;
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


    [Fact]
    public async Task CreateContactRequest_AddContactRequest()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);
        var userRepository = new UserRepository(_logger, dbContext);

        var senderUserObjectId = SampleData.UserObjectIds.First();
        var receiverUserObjectId = SampleData.UserObjectIds.ElementAt(6);

        // Testing
        var result = await userRepository.CreateContactRequest(senderUserObjectId, receiverUserObjectId);

        // Verification
        Assert.True(result);
    }

    [Fact]
    public async Task AcceptContactRequest_AcceptContactRequest()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);
        var userRepository = new UserRepository(_logger, dbContext);

        var senderUserObjectId = SampleData.UserObjectIds.ElementAt(2);
        var receiverUserObjectId = SampleData.UserObjectIds.ElementAt(4);

        // Testing
        var resultAccept = await userRepository.AcceptContactRequest(receiverUserObjectId, senderUserObjectId);

        // Verification
        Assert.True(resultAccept);
    }

    [Fact]
    public async Task DeleteContact_DeleteContact()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);
        var userRepository = new UserRepository(_logger, dbContext);

        var primaryUserObjectId = SampleData.UserObjectIds.First();
        var contactToDeleteUserObjectId = SampleData.UserObjectIds.ElementAt(2);

        // Testing
        var resultAccept = await userRepository.DeleteContact(primaryUserObjectId, contactToDeleteUserObjectId);

        // Verification
        Assert.True(resultAccept);
    }
}
