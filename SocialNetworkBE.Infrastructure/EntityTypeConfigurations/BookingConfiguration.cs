using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
   public void Configure(EntityTypeBuilder<Booking> builder)
   {
      builder.ToTable("Bookings");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.TotalPrice)
         .IsRequired();

      builder.HasOne(b => b.Match)
         .WithOne()
         .HasForeignKey<Booking>("MatchId")
         .OnDelete(DeleteBehavior.Cascade);
      
      builder.HasOne(f=> f.Field)
         .WithMany(b =>b.Bookings )
         .HasForeignKey("FieldId")
         .OnDelete(DeleteBehavior.Cascade);
      
      builder.HasOne(b=>b.ReservedBy)
         .WithMany(p=>p.Bookings)
         .HasForeignKey("PlayerId")
         .OnDelete(DeleteBehavior.Cascade);  
   }
}