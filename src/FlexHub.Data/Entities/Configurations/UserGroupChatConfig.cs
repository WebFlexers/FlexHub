using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlexHub.Data.Entities.Configurations;

public class UserGroupChatConfig : IEntityTypeConfiguration<UserGroupChat>
{
    public void Configure(EntityTypeBuilder<UserGroupChat> builder)
    {
        builder.HasKey(gcu => new { gcu.UserObjectId, gcu.GroupChatId });
    }
}
