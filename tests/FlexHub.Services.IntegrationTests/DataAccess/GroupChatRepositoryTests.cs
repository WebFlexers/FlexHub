using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Mocks;
using FlexHub.Services.IntegrationTests.Utilities;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace FlexHub.Services.IntegrationTests.DataAccess;

[Collection("Database collection")]
public class GroupChatRepositoryTests
{
    private readonly LocalDbInitializerFixture _fixture;
    private readonly ILogger<GroupChatRepository> _logger;

    public GroupChatRepositoryTests(ITestOutputHelper testOutputHelper, LocalDbInitializerFixture fixture)
    {
        _fixture = fixture;
        _logger = XUnitLogger.CreateLogger<GroupChatRepository>(testOutputHelper);
    }

    [Fact]
    public async Task GetGroupChatsFilteredByName_FetchGroupChatsFilteredByName()
    {
        // Preparation
        var dbContextFactory = new DbContextFactoryMock(_fixture, false);
        await using var groupChatRepository = new GroupChatRepository(_logger, dbContextFactory);

        var user = SampleData.UserObjectIds.ElementAt(2);
        var groupTitle = "Head";

        // Testing
        var groupChats = await groupChatRepository.GetGroupChatsFilteredByName(user, groupTitle);

        // Verification
        Assert.True(groupChats.Any());
    }

    [Fact]
    public async Task GetSortedGroupMessagesPaginated_FetchSortedGroupMessagesPaginated()
    {
        // Preparation
        var dbContextFactory = new DbContextFactoryMock(_fixture, false);
        await using var groupChatRepository = new GroupChatRepository(_logger, dbContextFactory);

        // Testing
        var groupMessages = await groupChatRepository.GetSortedGroupMessagesPaginated(2, 1, 10);
        foreach (var msg in groupMessages)
        {
            _logger.LogInformation("------------------------");
            _logger.LogInformation(msg.Message);
            _logger.LogInformation(msg.CreatedAt.ToString());
            _logger.LogInformation(msg.GroupChatId.ToString());
        }

        // Verification
        Assert.True(groupMessages.Any());
    }

    [Fact]
    public async Task StoreGroupMessage_StoreGroupMessage()
    {
        // Preparation
        var dbContextFactory = new DbContextFactoryMock(_fixture, true);
        await using var groupChatRepository = new GroupChatRepository(_logger, dbContextFactory);

        var userObjectId = SampleData.UserObjectIds.First();
        var groupId = 2;
        var message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

        // Testing
        var (isStoredSuccessfully, groupMessage) = await groupChatRepository.StoreGroupMessage(userObjectId, groupId, message);

        // Verification
        Assert.True(isStoredSuccessfully);
    }

    [Fact]
    public async Task RemoveUserFromGroupChat_RemoveUserFromGroupChat()
    {
        // Preparation
        var dbContextFactory = new DbContextFactoryMock(_fixture, true);
        await using var groupChatRepository = new GroupChatRepository(_logger, dbContextFactory);

        var userObjectId = SampleData.UserObjectIds.First();
        var groupChatId = 1;

        // Testing
        var result = await groupChatRepository.RemoveUserFromGroupChat(userObjectId, groupChatId);

        // Verification
        Assert.True(result);
    }
}
