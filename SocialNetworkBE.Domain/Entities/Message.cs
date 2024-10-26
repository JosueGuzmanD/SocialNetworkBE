namespace SocialNetworkBE.Domain.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public Player Sender { get; set; }
    public Player Receiver { get; set; }


}
