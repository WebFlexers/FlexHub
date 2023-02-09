using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class DirectMessageConfig : IEntityTypeConfiguration<DirectMessage>
{
    public void Configure(EntityTypeBuilder<DirectMessage> builder)
    {
        builder.HasKey(dm => dm.Id);
        builder.HasIndex(dm => new { dm.SenderUserObjectId, dm.ReceiverUserObjectId, dm.CreatedAt })
            .IsUnique();

        builder.Property(dm => dm.Message)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(dm => dm.SenderUserObjectId)
            .IsRequired();
        builder.Property(dm => dm.ReceiverUserObjectId)
            .IsRequired();

        builder
            .HasOne(dm => dm.SenderUser)
            .WithMany(user => user.DirectMessages)
            .HasForeignKey(dm => dm.SenderUserObjectId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(dm => dm.ReceiverUser)
            .WithMany()
            .HasForeignKey(dm => dm.ReceiverUserObjectId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
