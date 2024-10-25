namespace SocialNetworkBE.Domain.Entities;

public class Message
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public Player Sender { get; set; }
    public Player Receiver { get; set; }


}
