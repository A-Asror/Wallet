using VirtualWallet.Domain.Enums.User;

namespace VirtualWallet.Domain.Entities;

public class User : BaseEntity
{
    public string? Pinfl { get; set; } = null;
    public string? Tin { get; set; } = null;
    public string? LastName { get; set; } = null;
    public string? FirstName { get; set; } = null;
    public string? MiddleName { get; set; } = null;
    public UserType UserType { get; set; }
    public Guid ExternalId { get; set; }
}
