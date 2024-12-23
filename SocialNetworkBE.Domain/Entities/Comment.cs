﻿namespace SocialNetworkBE.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; }

    public Player Player { get; set; }
    public Post Post { get; set; }
    public List<Reaction> Reactions { get; set; }
}