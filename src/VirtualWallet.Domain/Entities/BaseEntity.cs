namespace VirtualWallet.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Boolean IsDeleted { get; protected set; }
}
