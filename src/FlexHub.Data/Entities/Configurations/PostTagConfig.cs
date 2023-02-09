using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class PostTagConfig : IEntityTypeConfiguration<PostTag>
{
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.HasKey(pt => new { pt.PostId, pt.TagId });
    }
}
