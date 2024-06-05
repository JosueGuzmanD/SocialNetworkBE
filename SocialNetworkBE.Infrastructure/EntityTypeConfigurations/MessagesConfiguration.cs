using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure.Configurations;

public class MessagesConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(x => x.Content).IsRequired();

        builder.HasOne(x => x.Sender)
            .WithMany(x => x.SentMessages)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(x => x.Receiver)
            .WithMany(x => x.ReceivedMessages)
            .HasForeignKey(x => x.ReceiverId)
             .OnDelete(DeleteBehavior.NoAction);
  
    }
}
