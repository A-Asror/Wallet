using System.ComponentModel.DataAnnotations;
using MediatR;
using VirtualWallet.Domain.Enums.Wallet;

namespace VirtualWallet.Application.UseCases.Wallets.CreateWalletHandler;

public class CreateWalletRequest: IRequest<CreateWalletResponse>
{
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public CurrencyCode CurrencyCode { get; set; }
    
    [Required]
    public WalletType WalletType { get; set; }
    
    public Guid? ExternalId { get; set; } = null;
    
}