using FlexHub.Data;
using Microsoft.EntityFrameworkCore;

namespace FlexHub.Services.DataAccess;

public class EfCoreRepositoryBase : IDisposable, IAsyncDisposable
{
    private bool _isOperationRunningOnMainDbContext = false;

    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private readonly ApplicationDbContext _mainDbContext;

    public EfCoreRepositoryBase(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        _mainDbContext = dbContextFactory.CreateDbContext();
    }

    public (ApplicationDbContext dbContext, bool createdNewDbContext) GetThreadSafeDbContext()
    {
        if (_isOperationRunningOnMainDbContext)
        {
            return (_dbContextFactory.CreateDbContext(), true);
        }

        _isOperationRunningOnMainDbContext = true;
        return (_mainDbContext, false);
    }

    /// <summary>
    /// If a new db context was created it gets disposed. Otherwise the running
    /// operation indicator on the main db context is reset.
    /// </summary>
    protected async Task CleanUpAsync(ApplicationDbContext? dbContext, bool createdNewDbContext)
    {
        if (dbContext != null && createdNewDbContext) 
            await dbContext.DisposeAsync();
        else
        {
            _isOperationRunningOnMainDbContext = false;
        }
    }

    public void Dispose()
    {
        _mainDbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _mainDbContext.DisposeAsync();
    }
}