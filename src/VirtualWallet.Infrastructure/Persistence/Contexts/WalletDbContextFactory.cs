using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VirtualWallet.Infrastructure.Persistence.Contexts;

public class WalletDbContextFactory : IDesignTimeDbContextFactory<WalletDbContext>
{
    public WalletDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../VirtualWallet.Api");
        // Загрузка конфигурации из appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Создание DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<WalletDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(connectionString);
        
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        
        return new WalletDbContext(optionsBuilder.Options, loggerFactory);
    }
}