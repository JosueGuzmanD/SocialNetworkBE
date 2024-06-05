namespace SocialNetworkBE.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public Guid UserGuid { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Birthdate { get; set; }
    public string Bio { get; set; }

    public string AvatarUrl { get; set; }
    public DateTime creationDate { get; set; }
    public DateTime updatedDate { get; set; }

    public ICollection<Comment> Comments { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Friendship> Friendships { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<GroupMembership> GroupMemberships { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Reaction> Reactions { get; set; }
    public ICollection<Group> Groups { get; set; }

    public ICollection<Message> SentMessages { get; set; }
    public ICollection<Message> ReceivedMessages { get; set; }


}
