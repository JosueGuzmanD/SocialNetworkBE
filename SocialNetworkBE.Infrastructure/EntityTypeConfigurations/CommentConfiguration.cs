using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(c => c.Content).IsRequired();

        builder.HasMany(c => c.Reactions)
            .WithOne(r => r.Comment)
            .HasForeignKey("CommentId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Player)
            .WithMany(c => c.Comments)
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Post)
            .WithMany(c => c.Comments)
            .HasForeignKey("PostId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}