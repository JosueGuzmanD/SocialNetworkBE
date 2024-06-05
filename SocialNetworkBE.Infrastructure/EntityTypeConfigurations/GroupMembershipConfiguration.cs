using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class GroupMembershipConfiguration : IEntityTypeConfiguration<GroupMembership>
{
    public void Configure(EntityTypeBuilder<GroupMembership> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.role).IsRequired();
        builder.Property(e => e.JoinedAt).IsRequired();


        builder.HasOne(e => e.User)
            .WithMany(e => e.GroupMemberships)
            .HasForeignKey(e => e.UserId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(e => e.Group)
            .WithMany(e => e.GroupMemberships)
            .HasForeignKey(e => e.GroupId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.UserId).IsUnique();

    }
}
