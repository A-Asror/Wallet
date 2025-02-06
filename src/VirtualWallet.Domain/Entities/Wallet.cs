using VirtualWallet.Domain.Enums.Wallet;

namespace VirtualWallet.Domain.Entities;

public class Wallet : BaseEntity
{
    public long Balance { get; set; }
    public string Pan { get; set; }
    public string Expire { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
    public Guid ExternalId { get; set; }
    public WalletType WalletType { get; set; }
    public WalletState WalletState { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<WalletToken> WalletTokens { get; } = new List<WalletToken>();
    public ICollection<Transaction> Transactions { get; } = new List<Transaction>();
}
