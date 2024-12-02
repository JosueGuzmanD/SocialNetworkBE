using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(a => a.Player)
            .WithOne(p => p.ApplicationUser)
            .HasForeignKey<ApplicationUser>(a => a.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);        
    }
}