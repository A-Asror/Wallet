using Ardalis.Specification.EntityFrameworkCore;
using VirtualWallet.Domain.Common.Interfaces;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Infrastructure.Persistence.Contexts;

namespace VirtualWallet.Infrastructure.Repository.Users;

public class UserRepository: RepositoryBase<User>, IUserRepository, ITransientService
{
    private readonly WalletDbContext _dbContext;

    public UserRepository(WalletDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Add(user);
        await Task.CompletedTask;
    }
}