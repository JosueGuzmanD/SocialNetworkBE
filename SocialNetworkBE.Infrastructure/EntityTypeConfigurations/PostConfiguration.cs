using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Content).IsRequired();

        builder.HasOne(p => p.CreatedBy)
            .WithMany(u => u.Posts)
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}