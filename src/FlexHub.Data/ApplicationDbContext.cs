using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FlexHub.Data.Entities;
using FlexHub.Data.Seeding;
using Microsoft.Extensions.Logging;

namespace FlexHub.Data;

public class ApplicationDbContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public ApplicationDbContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (_loggerFactory != null)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Extra data for testing
        List<Post> posts = new List<Post>()
        {
            new Post
            {
                Id = 350,
                Title = "Post 350",
                Content = "Lorem ipsum dolor sit amet",
                UserObjectId = SampleData.UserObjectIds.First(),
            },
            new Post
            {
                Id = 956,
                Title = "Post 956",
                Content = "Lorem ipsum dolor sit amet",
                UserObjectId = SampleData.UserObjectIds.First(),
            },
            new Post
            {
                Id = 876,
                Title = "Post 876",
                Content = "Lorem ipsum dolor sit amet",
                UserObjectId = SampleData.UserObjectIds.Last(),
            },
        };

        List<PostTag> postTags = new List<PostTag>()
        {
            new PostTag() { PostId = posts[0].Id, TagId = 4 },
            new PostTag() { PostId = posts[0].Id, TagId = 10 },
            new PostTag() { PostId = posts[1].Id, TagId = 4 },
            new PostTag() { PostId = posts[1].Id, TagId = 10 },
            new PostTag() { PostId = posts[2].Id, TagId = 4 },
            new PostTag() { PostId = posts[2].Id, TagId = 10 },
            new PostTag() { PostId = posts[2].Id, TagId = 3 },
        };

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Extra data for testing
        modelBuilder.Entity<Post>().HasData(posts);
        modelBuilder.Entity<PostTag>().HasData(postTags);

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
