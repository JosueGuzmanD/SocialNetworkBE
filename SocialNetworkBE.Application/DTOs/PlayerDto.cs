namespace SocialNetworkBE.Application.DTOs;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? AvatarUrl { get; set; }

    public string Bio { get; set; }
}

public class CreatePlayerDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? AvatarUrl { get; set; }

    public string Bio { get; set; }
}

public class UpdatePlayerDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? AvatarUrl { get; set; }

    public string? Bio { get; set; }
}

public class PlayerQueryDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int? MinGoals { get; set; }
    public int? MaxGoals { get; set; }
}