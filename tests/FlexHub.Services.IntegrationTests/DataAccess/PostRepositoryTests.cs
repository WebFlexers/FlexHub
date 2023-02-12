using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
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

    [Fact]
    public async Task GetPaginatedPostsSortedByPreferredTags_FetchPaginatedPostsSortedByPreferredTags()
    {
        // Preparation
        using var dbContext = _fixture.GetDbContextLocalDb(true);

        var postRepository = new PostRepository(_logger, dbContext);

        var user = SampleData.UserObjectIds.First();

        List<TagDTO> prefferedTagsDTOs = new List<TagDTO>() 
        {
            new TagDTO(){Id = 3, Value = "History"},
            new TagDTO(){Id = 9, Value = "Religion"},
            new TagDTO(){Id = 10, Value = "Sports"},
        };

        List<Tag> prefferedTags = new List<Tag>();

        foreach (var tagDTO in prefferedTagsDTOs)
        {
            prefferedTags.Add(new Tag
            {
                Id = tagDTO.Id,
                Value = tagDTO.Value,
            });
        }

        // Testing
        var posts = await postRepository.GetPaginatedPostsSortedByPreferredTags(prefferedTags, 1, 20);

        foreach (var tag in prefferedTags)
        {
            _logger.LogInformation(tag.Value);
        }

        int matchedTagsCounter;
        foreach (var post in posts)
        {
            matchedTagsCounter = 0;

            _logger.LogInformation("--------- POST: " + post.Title + " ---------");

            foreach (var tag in post.Tags)
            {
                _logger.LogInformation(tag.Value);

                foreach (var prefferedTag in prefferedTags)
                {
                    if (prefferedTag.Value.Equals(tag.Value))
                        matchedTagsCounter++;
                }
            }

            _logger.LogInformation("Matches: " + matchedTagsCounter);
        }

        // Verification
        Assert.True(posts.Any());

    }
}
