namespace SocialNetworkBE.Domain.Entities;

public abstract class BaseEntity
{
    Guid Id { get; set; }
    DateTime CreationDate { get; set; }
    DateTime UpdatedDate { get; set; }
    bool IsDeleted { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void UpdateTimestamp()
    {
        UpdatedDate = DateTime.UtcNow;
    }

    public void MarkAsDeleted()
    {
        IsDeleted = true;
        UpdateTimestamp();
    }
}
