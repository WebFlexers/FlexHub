using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Utilities;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace FlexHub.Services.IntegrationTests.DataAccess;

[Collection("Database collection")]
public class DirectMessageRepositoryTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly LocalDbInitializerFixture _fixture;
    private readonly ILogger<DirectMessageRepository> _logger;

    public DirectMessageRepositoryTests(ITestOutputHelper testOutputHelper, LocalDbInitializerFixture fixture)
    {
        _testOutputHelper = testOutputHelper;
        _fixture = fixture;
        _logger = XUnitLogger.CreateLogger<DirectMessageRepository>(testOutputHelper);
    }

    [Fact]
    public async Task StoreMessage_ShouldSaveAMessageToTheDB()
    {
        // Preparation
        var loggerFactory = new LoggerFactory();
        loggerFactory.AddProvider(new XUnitLoggerProvider(_testOutputHelper));
        using var dbContext = _fixture.GetDbContextLocalDb(loggerFactory, true);

        var directMessageRepository = new DirectMessageRepository(_logger, dbContext);

        var senderUserObjectId = SampleData.UserObjectIds.First();
        var receiverUserObjectId = SampleData.UserObjectIds.Last();
        var message = "This is a test message!";

        // Testing
        var isStoredSuccessfully = await directMessageRepository.StoreMessage(senderUserObjectId, receiverUserObjectId, message);

        // Verification
        Assert.True(isStoredSuccessfully);

        var storedMessage = dbContext.DirectMessages
            .Where(dm =>
                dm.SenderUserObjectId == senderUserObjectId &&
                dm.ReceiverUserObjectId == receiverUserObjectId &&
                dm.Message.Equals(message)).ToList();

#pragma warning disable xUnit2012
        Assert.True(storedMessage.Any(dm => dm.Message.Equals(message)));
#pragma warning restore xUnit2012
    }

    [Fact]
    public async Task GetDirectMessagesOf2UsersPaginated_FetchDirectMessagesOf2UsersPaginated()
    {
        // Preparation
        await using var dbContext = _fixture.GetDbContextLocalDb(false);

        var directMessageRepository = new DirectMessageRepository(_logger, dbContext);

        var senderUserId = SampleData.UserObjectIds.First();
        var contactUserId = SampleData.UserObjectIds.Last();

        //Testing
        var directMessages = await directMessageRepository.GetDirectMessagesOf2UsersPaginated(senderUserId, contactUserId, 1, 10);

        _logger.LogInformation("Sender: " + senderUserId + ", Contact: " + contactUserId);
        foreach (var directMessage in directMessages)
        {
            _logger.LogInformation("Meesage: " + directMessage);
        }

        // Verification
        Assert.True(directMessages.Any());
    }
}
