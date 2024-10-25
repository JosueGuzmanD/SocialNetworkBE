using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(e => e.UserGuid).IsRequired(); 
            builder.HasIndex(e => e.UserGuid).IsUnique();

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Friendships)
                .WithOne(x => x.User1)
                .HasForeignKey(x => x.User1Id);

            builder.HasMany(x => x.GroupMemberships)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasMany(x => x.Notifications)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Reactions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(e => e.SentMessages)
                 .WithOne(e => e.Sender)
                 .HasForeignKey(e => e.SenderId);

            builder.HasMany(e => e.ReceivedMessages)
                 .WithOne(e => e.Receiver)
                 .HasForeignKey(e => e.ReceiverId);


        }
    }
}
