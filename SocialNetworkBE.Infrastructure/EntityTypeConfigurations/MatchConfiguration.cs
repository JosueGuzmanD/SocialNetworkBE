using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Match");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.MatchDuration, matchDuration =>
        {
            matchDuration.ToTable("MatchDuration");
            matchDuration.Property(x => x.HalfTimeDuration).IsRequired();
            matchDuration.Property(x => x.AddedTime).IsRequired();
            matchDuration.Property(x => x.WaterBreakDuration);
            matchDuration.Property(x => x.ExtraTime);
            matchDuration.Property(x => x.TotalTime).IsRequired();
        });

        builder.OwnsOne(m => m.Stats, stats =>
        {
            stats.Property(s => s.GoalsTeamA).IsRequired();
            stats.Property(s => s.GoalsTeamB).IsRequired();

            stats.OwnsMany(s => s.Scorers, scorer =>
            {
                scorer.ToTable("Scorers");
                scorer.HasKey(s => s.Id);
                scorer.Property(s => s.PlayerId).IsRequired();
                scorer.Property(s => s.IsTeamA).IsRequired();
                scorer.WithOwner().HasForeignKey("MatchId");
            });
        });

        builder.OwnsOne(m => m.Teams, teams =>
        {
            teams.WithOwner();

            teams.HasOne(t => t.TeamA)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            teams.HasOne(t => t.TeamB)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.HasOne(m => m.FootballField)
            .WithMany(f => f.Matches)
            .HasForeignKey("FootballFieldId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(m => m.Status).IsRequired();

        builder.HasOne(m => m.CreatedBy)
            .WithMany(p => p.CreatedMatches)
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}