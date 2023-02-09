using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class PostConfig : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(post => post.Id);

        builder.Property(post => post.Title)
            .IsRequired()
            .HasMaxLength(40);
        builder.Property(post => post.Content)
            .IsRequired()
            .HasColumnType("nvarchar(max)");
        builder.Property(post => post.UserObjectId)
            .IsRequired();

        builder
            .HasOne(post => post.User)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.UserObjectId);
    }
}
