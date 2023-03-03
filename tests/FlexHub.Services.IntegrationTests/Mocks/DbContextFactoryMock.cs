using FlexHub.Data;
using FlexHub.Services.IntegrationTests.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace FlexHub.Services.IntegrationTests.Mocks;

public class DbContextFactoryMock : IDbContextFactory<ApplicationDbContext>
{
    private readonly LocalDbInitializerFixture _fixture;
    private readonly bool _beginTransaction;

    public DbContextFactoryMock(LocalDbInitializerFixture fixture, bool beginTransaction)
    {
        _fixture = fixture;
        _beginTransaction = beginTransaction;
    }

    public ApplicationDbContext CreateDbContext()
    {
        return _fixture.GetDbContextLocalDb(_beginTransaction);
    }
}
