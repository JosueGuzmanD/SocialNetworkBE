using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.OwnsOne(p => p.Stats, statsBuilder =>
        {
            statsBuilder.Property(s => s.TotalMatchesPlayed)
                .IsRequired()
                .HasDefaultValue(0);

            statsBuilder.Property(s => s.GoalsScored)
                .IsRequired()
                .HasDefaultValue(0);

            statsBuilder.Property(s => s.Wins)
                .IsRequired()
                .HasDefaultValue(0);
        });
        
        builder.HasMany(p => p.TeamHistory)
            .WithOne(tm => tm.Player)
            .HasForeignKey(tm => tm.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}