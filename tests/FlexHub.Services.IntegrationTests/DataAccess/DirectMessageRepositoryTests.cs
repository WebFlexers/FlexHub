using FlexHub.Data.Seeding;
using FlexHub.Services.DataAccess;
using FlexHub.Services.IntegrationTests.Fixtures;
using FlexHub.Services.IntegrationTests.Mocks;
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

        var dbContextFactory = new DbContextFactoryMock(_fixture, true);
        await using var directMessageRepository = new DirectMessageRepository(_logger, dbContextFactory);

        var senderUserObjectId = SampleData.UserObjectIds.First();
        var receiverUserObjectId = SampleData.UserObjectIds.Last();
        var message = "This is a test message!";

        // Testing
        var isStoredSuccessfully = await directMessageRepository.StoreMessage(senderUserObjectId, receiverUserObjectId, message);

        // Verification
        Assert.True(isStoredSuccessfully);
    }

    [Fact]
    public async Task GetDirectMessagesOf2UsersPaginated_FetchDirectMessagesOf2UsersPaginated()
    {
        // Preparation
        var dbContextFactory = new DbContextFactoryMock(_fixture, false);
        await using var directMessageRepository = new DirectMessageRepository(_logger, dbContextFactory);

        var senderUserId = SampleData.UserObjectIds.First();
        var contactUserId = SampleData.UserObjectIds.Last();

        //Testing
        var directMessages = await directMessageRepository.GetDirectMessagesOf2UsersPaginated(senderUserId, contactUserId, 1, 10);

        _logger.LogInformation("Sender: " + senderUserId + ", Contact: " + contactUserId);
        foreach (var directMessage in directMessages)
        {
            _logger.LogInformation("Message: " + directMessage);
        }

        // Verification
        Assert.True(directMessages.Any());
    }
}
