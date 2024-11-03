using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class TeamMembershipConfiguration : IEntityTypeConfiguration<TeamMembership>
{
    public void Configure(EntityTypeBuilder<TeamMembership> builder)
    {
        builder.HasKey(tm => tm.Id);

        builder.HasOne(tm => tm.Player)
            .WithMany(p => p.TeamHistory)
            .HasForeignKey(tm => tm.PlayerId);

        builder.HasOne(tm => tm.Team)
            .WithMany()
            .HasForeignKey(tm => tm.TeamId);

        builder.Property(tm => tm.JoinedDate)
            .IsRequired();
    }
}