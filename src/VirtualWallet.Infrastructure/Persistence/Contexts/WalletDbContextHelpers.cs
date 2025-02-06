using Microsoft.EntityFrameworkCore;
using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Infrastructure.Persistence.Contexts;

internal static class WalletDbContextHelpers
{
    public static void DatabaseModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasIndex(t => t.RefTransactionId);
            entity.HasIndex(t => t.ExternalId);
            entity.HasOne(t => t.Wallet)
                .WithMany()
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity => { entity.HasIndex(u => u.ExternalId); });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasIndex(w => w.ExternalId);
            entity.HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<WalletToken>(entity =>
        {
            entity.HasOne(wt => wt.Wallet)
                .WithMany()
                .HasForeignKey(wt => wt.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}