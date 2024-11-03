namespace SocialNetworkBE.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }

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