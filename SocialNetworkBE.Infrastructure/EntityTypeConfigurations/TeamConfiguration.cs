using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class TeamConfiguration: IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(t => t.Stats, statsBuilder =>
        {
            statsBuilder.Property(s => s.TotalMatchesPlayed).IsRequired();
            statsBuilder.Property(s => s.Wins).IsRequired();
            statsBuilder.Property(s => s.Losses).IsRequired();
        });

        builder.Property(t => t.isRecurrent).IsRequired();
    }
}