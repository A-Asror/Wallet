namespace VirtualWallet.Domain.Enums.Transactions;

public enum TransactionType
{
    AddFunds = 1,  // Пополнение баланса
    Credit = 2,  
    Withdraw = 3,  // Снятие с баланса
    Debit = 4,  // Снятие(оплата)
    CancelDebit = 5,  // Отмена снятия(оплаты)
    Transfer = 7,  // Перевод между картами
    Cashback = 10,  // Зачисление кешбека
    CancelCashback = 11,  // Отмена кешбека
}
