using VirtualWallet.Domain.Enums.Transactions;
using VirtualWallet.Domain.Enums.Wallet;

namespace VirtualWallet.Domain.Entities;

public class Transaction : BaseEntity
{
    public long Amount { get; set; }
    public long OldBalance { get; set; }
    public long NewBalance { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public string MerchantId { get; set; }
    public string TerminalId { get; set; }
    public TransactionType Type { get; set; }
    public TransactionStatus Status { get; set; }
    public Guid RefTransactionId { get; set; }
    public Guid ExternalId { get; set; }
    public DirectionType Direction { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
    
    public Guid WalletId { get; set; }
    public Wallet Wallet { get; set; }
}