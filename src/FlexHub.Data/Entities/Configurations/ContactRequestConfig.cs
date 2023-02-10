using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class ContactRequestConfig : IEntityTypeConfiguration<ContactRequest>
{
    public void Configure(EntityTypeBuilder<ContactRequest> builder)
    {
        builder.HasKey(cr => new { cr.SenderUserObjectId, cr.ReceiverUserObjectId });

        builder
            .HasOne(cr => cr.SenderUser)
            .WithMany(user => user.ContactRequests)
            .HasForeignKey(contact => contact.SenderUserObjectId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(contact => contact.ReceiverUser)
            .WithMany()
            .HasForeignKey(contact => contact.ReceiverUserObjectId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
