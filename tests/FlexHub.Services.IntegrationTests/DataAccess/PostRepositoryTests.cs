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
        var postTitle = "I Love Awesome Steel Car!";

        // Testing
        var posts = await postRepository.GetPaginatedPostsFilteredByTitle(postTitle, 1, 10);

        foreach (var post in posts)
        {
            _logger.LogInformation(post.Title);
        }

        // Verification
        Assert.True(posts.Count == 1);
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

                foreach (var preferredTag in prefferedTags)
                {
                    if (preferredTag.Value.Equals(tag.Value))
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
        await using var dbContext = _fixture.GetDbContextLocalDb(false);

        var postRepository = new PostRepository(_logger, dbContext);

        // Create Tags
        List<Tag> tags = new List<Tag> {
            new Tag { Id = 4, Value = "Mathematics" },
            new Tag { Id = 10, Value = "Sports" },
        };

        // Testing
        var result = await postRepository.GetPaginatedPostsFilteredByTags(tags, 1, 10);

        foreach (var post in result)
        {
            int necessaryTagsCount = 0;

            foreach (var tag in post.Tags)
            {
                if (tags.Any(t => t.Id.Equals(tag.Id)))
                {
                    necessaryTagsCount++;
                }
            }

            // Verification
            Assert.Equal(tags.Count, necessaryTagsCount);
        }

    }

    [Fact]
    public async Task CreatePost_CreatePost()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(true);

        var postRepository = new PostRepository(_logger, dbContext);

        var user = SampleData.UserObjectIds.First();

        // Create Tags
        var tagDTOs = new List<TagDTO> {
            new TagDTO { Id = 4, Value = "Mathematics" },
            new TagDTO { Id = 10, Value = "Sports" },
        };

        // Testing
        var postDTO = new CreatePostDTO()
        {
            Title = "Some story about a guy",
            Content = "Once upon a time there was a guy",
            UserObjectId = user,
            Tags = tagDTOs
        };

        var result = postRepository.CreatePost(postDTO);

        // Verification
        Assert.True(await result);
    }
}
