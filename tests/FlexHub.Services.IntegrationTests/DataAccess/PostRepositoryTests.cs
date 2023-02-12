using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Utilities;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace FlexHub.Services.IntegrationTests.DataAccess;

[Collection("Database collection")]
public class PostRepositoryTests
{
    private readonly LocalDbInitializerFixture _fixture;
    private readonly ILogger<PostRepository> _logger;

    public PostRepositoryTests(ITestOutputHelper testOutputHelper, LocalDbInitializerFixture fixture)
    {
        _fixture = fixture;
        _logger = XUnitLogger.CreateLogger<PostRepository>(testOutputHelper);
    }

    [Fact]
    public async Task GetPaginatedPostsFilteredByTitle_FetchPaginatedPostsFilteredByTitle()
    {
        // Preparation
        using var dbContext = _fixture.GetDbContextLocalDb(true);
        var postRepository = new PostRepository(_logger, dbContext);
        var postTitle = "I Like";

        // Testing
        var posts = await postRepository.GetPaginatedPostsFilteredByTitle(postTitle, 1, 10);

        foreach(var post in posts)
        {
            _logger.LogInformation(post.Title);
        }

        // Verification
        Assert.True(posts.Count == 10);

    }
}
