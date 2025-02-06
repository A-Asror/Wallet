using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Infrastructure.Repository.Users;

public interface IUserRepository
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken);
}