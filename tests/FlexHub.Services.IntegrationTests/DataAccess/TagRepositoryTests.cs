using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Mocks;
using FlexHub.Services.IntegrationTests.Utilities;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace FlexHub.Services.IntegrationTests.DataAccess;

[Collection("Database collection")]
public class TagRepositoryTests
{
    private readonly LocalDbInitializerFixture _fixture;
    private readonly ILogger<TagRepository> _logger;

    public TagRepositoryTests(ITestOutputHelper testOutputHelper, LocalDbInitializerFixture fixture)
    {
        _fixture = fixture;
        _logger = XUnitLogger.CreateLogger<TagRepository>(testOutputHelper);
    }

    [Fact]
    public async Task GetUserTags_ShouldFetchUserTags()
    {
        // Preparation
        var dbContextFactory = new DbContextFactoryMock(_fixture, false);
        await using var tagRepository = new TagRepository(_logger, dbContextFactory);
        string userId = SampleData.UserObjectIds.First();

        // Testing
        var userTags = await tagRepository.GetUserTags(userId);

        foreach (var tag in userTags)
        {
            _logger.LogInformation(tag.Value);
        }

        // Verification
        Assert.True(userTags.Any());

#pragma warning disable xUnit2012
        //Assert.True(storedMessage.Any(dm => dm.Message.Equals(message)));
    }
}
