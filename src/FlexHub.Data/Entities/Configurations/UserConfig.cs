using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.ObjectId);

        builder.Property(user => user.ObjectId)
            .IsRequired(true)
            .HasMaxLength(40);
        builder.Property(user => user.GivenName)
            .IsRequired(true)
            .HasMaxLength(60);
        builder.Property(user => user.Surname)
            .IsRequired()
            .HasMaxLength(60);
        builder.Property(user => user.DisplayName)
            .IsRequired()
            .HasMaxLength(25);
        builder.Property(user => user.Country)
            .IsRequired()
            .HasMaxLength(60);
        builder.Property(user => user.EmailAddress)
            .IsRequired()
            .HasMaxLength(254);
        builder.Property(user => user.CreatedAt)
            .IsRequired();
        builder.Property(user => user.UpdatedAt)
            .IsRequired();
    }
}
