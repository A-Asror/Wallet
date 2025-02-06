using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualWallet.Application.UseCases.Wallets.CreateWalletHandler;

namespace VirtualWallet.WebApi.Controllers;

[ApiVersion("1.0")]
public class WalletController : BaseApiController
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateWalletResponse>> CreateWallet([FromBody] CreateWalletRequest request)
    {
        var wallet  = await _mediator.Send(request);
        return wallet;
    }
}