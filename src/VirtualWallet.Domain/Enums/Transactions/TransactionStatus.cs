namespace VirtualWallet.Domain.Enums.Transactions;

public enum TransactionStatus
{
    Created = 0,
    Success = 1,
    Failed = 2,
    Waiting = 3,
    Cancelled = 4,
}