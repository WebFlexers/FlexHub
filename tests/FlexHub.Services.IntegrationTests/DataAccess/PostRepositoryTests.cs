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
        await using var dbContext = _fixture.GetDbContextLocalDb(true);
        var postRepository = new PostRepository(_logger, dbContext);
        var postTitle = "I Adore";

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
        await using var dbContext = _fixture.GetDbContextLocalDb(true);

        var postRepository = new PostRepository(_logger, dbContext);

        var user = SampleData.UserObjectIds.First();

        List<TagDTO> prefferedTagsDTOs = new List<TagDTO>() 
        {
            new TagDTO(){Id = 3, Value = "History"},
            new TagDTO(){Id = 9, Value = "Religion"},
            new TagDTO(){Id = 10, Value = "Sports"},
            new TagDTO(){Id = 4, Value = "Mathematics"},
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
        var posts = await postRepository.GetPaginatedPostsSortedByPreferredTags(prefferedTags, 3, 10);

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

    [Fact]
    public async Task GetPaginatedPostsFilteredByTags_FetchPaginatedPostsFilteredByTags()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);

        var postRepository = new PostRepository(_logger, dbContext);

        var user = SampleData.UserObjectIds.First();

        List<TagDTO> tagsDTOs = new List<TagDTO>()
        {
            new TagDTO(){Id = 2, Value = "Music"},
            new TagDTO(){Id = 5, Value = "Literature"},
            new TagDTO(){Id = 6, Value = "Geography"},
        };

        List<Tag> tags = new List<Tag>();
        foreach (var tagDTO in tagsDTOs)
        {
            tags.Add(new Tag
            {
                Id = tagDTO.Id,
                Value = tagDTO.Value,
            });
        }

        // Testing
        var posts = await postRepository.GetPaginatedPostsFilteredByTags(tags, 1, 10);

        foreach (var tag in tags)
        {
            _logger.LogInformation(tag.Value);
        }

        int matchedTagsCounter;
        foreach (var post in posts)
        {
            matchedTagsCounter = 0;

            _logger.LogInformation("--------- POST: " + post.PostId + " " + post.Title + "---------");

            foreach (var tag in post.Tags)
            {
                _logger.LogInformation(tag.Value);

                foreach (var prefferedTag in tags)
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
