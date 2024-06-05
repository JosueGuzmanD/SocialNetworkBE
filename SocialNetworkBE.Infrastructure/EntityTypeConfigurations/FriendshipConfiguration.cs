using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.Configurations;

public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(f => f.User1)
             .WithMany(u => u.Friendships)
             .HasForeignKey(f => f.User1Id)
             .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.User2)
               .WithMany()
               .HasForeignKey(f => f.User2Id)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
