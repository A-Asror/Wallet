using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Helpers;


namespace VirtualWallet.Infrastructure.Persistence.Contexts;

public class WalletDbContext : DbContext
{
    private readonly DateTime _dateTime; // Service for getting current date and time
    private readonly ILoggerFactory _loggerFactory; // Factory for creating logger instances

    public WalletDbContext(
        DbContextOptions<WalletDbContext> options,
        ILoggerFactory loggerFactory
    ) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // Disable tracking of query results in change tracker
        _dateTime = DateTimeHelper.NewDateTime();
        _loggerFactory = loggerFactory;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Wallet> Wallet { get; set; }
    public DbSet<WalletToken> WalletToken { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added: // If entity is being added to database
                    entry.Entity.CreatedAt = _dateTime; // Set created date and time to current UTC time using injected service
                    break;

                case EntityState.Modified: // If entity is being modified in database
                    entry.Entity.UpdatedAt = _dateTime; // Set last modified date and time to current UTC time using injected service
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken); // Call base method to save changes asynchronously with specified cancellation token
    }
}