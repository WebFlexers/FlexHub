using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class GroupChatConfig : IEntityTypeConfiguration<GroupChat>
{
    public void Configure(EntityTypeBuilder<GroupChat> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(gc => gc.Title)
            .IsRequired()
            .HasMaxLength(60);
    }
}
