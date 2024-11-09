namespace SocialNetworkBE.Application.DTOs;

public class CreatePlayerDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? AvatarUrl { get; set; }
}