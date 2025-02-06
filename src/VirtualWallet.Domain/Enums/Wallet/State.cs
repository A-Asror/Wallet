namespace VirtualWallet.Domain.Enums.Wallet;

public enum WalletState
{
    Unknown = 0, // Не определено(Создан)
    Active = 1,  // Активно
    Disable = 2,  // Время карты истек
    Frozen = 3,  // Заморожен
    Disabled = 4, // Выключен
    Hold = 5 // Приостановлено
}