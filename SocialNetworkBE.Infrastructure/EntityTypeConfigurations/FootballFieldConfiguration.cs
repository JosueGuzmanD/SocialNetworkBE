using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.EntityTypeConfigurations;

public class FootballFieldConfiguration: IEntityTypeConfiguration<FootballField>
{
    public void Configure(EntityTypeBuilder<FootballField> builder)
    {
        builder.HasKey(f => f.Id);
        
        builder.Property(f=> f.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(f=> f.FieldCapacity)
            .HasColumnName("FieldCapacity")
            .IsRequired();
        
        builder.Property(f=> f.FieldType)
            .HasColumnName("FieldType")
            .IsRequired();
        
        builder.Property(f=> f.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();builder.Property(f=> f.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();builder.Property(f=> f.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(f => f.Address, address =>
        {
            
            address.Property(a => a.Street)
                .HasColumnName("Street")
                .HasMaxLength(100)
                .IsRequired();

            address.Property(a => a.City)
                .HasColumnName("City")
                .HasMaxLength(50)
                .IsRequired();

            address.Property(a => a.PostalCode)
                .HasColumnName("PostalCode")
                .HasMaxLength(10)
                .IsRequired();

            address.Property(a => a.Country)
                .HasColumnName("Country")
                .HasMaxLength(50)
                .IsRequired();
        });
    }
}