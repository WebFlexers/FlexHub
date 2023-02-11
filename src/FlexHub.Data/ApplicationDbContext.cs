using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FlexHub.Data.Entities;
using FlexHub.Data.Seeding;

namespace FlexHub.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        new SampleData().Seed(modelBuilder);
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactRequest> ContactRequests { get; set; }
    public DbSet<DirectMessage> DirectMessages { get; set; }
    public DbSet<GroupChat> GroupChats { get; set; }
    public DbSet<GroupMessage> GroupMessages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostTag> PostsTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroupChat> UsersGroupChats { get; set; }
    public DbSet<UserTag> UsersTags { get; set; }
}
