using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => new { c.UserObjectId, c.ContactObjectId });

        builder
            .HasOne(contact => contact.User)
            .WithMany(user => user.Contacts)
            .HasForeignKey(contact => contact.UserObjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(contact => contact.ContactUser)
            .WithMany()
            .HasForeignKey(contact => contact.ContactObjectId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
