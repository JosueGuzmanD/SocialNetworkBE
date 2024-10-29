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

        builder.HasOne(p=>p.CreatedBy)
            .WithOne(u=>u.Post)
            .HasForeignKey("PostId")
            .OnDelete(DeleteBehavior.Restrict);
        
        
        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId);

        builder.HasMany(x => x.Reactions)
           .WithOne(x => x.Post)
           .HasForeignKey(x => x.PostId);



    }
}
