using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class GroupMessageConfig : IEntityTypeConfiguration<GroupMessage>
{
    public void Configure(EntityTypeBuilder<GroupMessage> builder)
    {
        builder.HasKey(gm => gm.Id);
        builder.HasIndex(gm => new { gm.GroupChatId, gm.CreatedAt })
            .IsUnique();

        builder.Property(gm => gm.Message)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(gm => gm.SenderUserObjectId)
            .IsRequired();

        builder
            .HasOne(gm => gm.SenderUser)
            .WithMany()
            .HasForeignKey(gm => gm.SenderUserObjectId);

        builder
            .HasOne(gm => gm.GroupChat)
            .WithMany(gc => gc.GroupMessages)
            .HasForeignKey(gm => gm.GroupChatId);
    }
}
