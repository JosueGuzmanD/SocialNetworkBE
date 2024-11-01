using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Reactions)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Reactions)
            .HasForeignKey("PostId");

        builder.HasOne(x => x.Comment)
            .WithMany(x => x.Reactions)
            .HasForeignKey("CommentId");

    }
}
