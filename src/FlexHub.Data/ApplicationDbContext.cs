using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FlexHub.Data.Seeding;

namespace FlexHub.Data;

public class ApplicationDbContext : DbContext
{
    private readonly ISampleData _sampleData;

    public ApplicationDbContext(DbContextOptions options, ISampleData sampleData) : base(options)
    {
        _sampleData = sampleData;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        _sampleData.Seed();
    }
}
