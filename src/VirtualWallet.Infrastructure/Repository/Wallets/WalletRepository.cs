using Ardalis.Specification.EntityFrameworkCore;
using VirtualWallet.Domain.Common.Interfaces;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Infrastructure.Persistence.Contexts;

namespace VirtualWallet.Infrastructure.Repository.Wallets;


public class WalletRepository : RepositoryBase<Wallet>, IWalletRepository, ITransientService
{
    private readonly WalletDbContext _dbContext;

    public WalletRepository(WalletDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateWalletAsync(Wallet wallet)
    {
        _dbContext.Wallet.Add(wallet);
        await Task.CompletedTask;
    }
}