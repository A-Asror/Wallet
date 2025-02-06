using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Infrastructure.Repository.Wallets;

public interface IWalletRepository
{
    Task CreateWalletAsync(Wallet wallet);
}