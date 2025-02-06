namespace VirtualWallet.Domain.Entities;

public class WalletToken: BaseEntity
{
    public string Token { get; set; }

    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; }
}