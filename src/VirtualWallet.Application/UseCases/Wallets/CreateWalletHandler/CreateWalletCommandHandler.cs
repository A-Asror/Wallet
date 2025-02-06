// using VirtualWallet.Domain.Entities;
//
// using MediatR;
// using VirtualWallet.Infrastructure.Repository.Wallets;
//
//
// namespace VirtualWallet.Application.UseCases.Wallets.CreateWalletHandler;
//
// public class CreateWalletCommandHandler: IRequestHandler<CreateWalletRequest, CreateWalletResponse>
// {
//     private readonly IWalletRepository _walletRepository;
//
//     public CreateWalletCommandHandler(IWalletRepository walletRepository)
//     {
//         _walletRepository = walletRepository;
//     }
//     
//     public async Task<CreateWalletResponse> Handle(CreateWalletRequest request, CancellationToken cancellationToken)
//     {
//         var wallet = new Wallet
//         {
//             
//         };
//         return new CreateWalletResponse
//         {
//             
//         };
//     }
// }