using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualWallet.Application.UseCases.Users.CreateUserHandler;

namespace VirtualWallet.WebApi.Controllers;

[ApiVersion("1.0")]
public class UserController : BaseApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateWallet([FromBody] CreateUserRequest request)
    {
        var user  = await _mediator.Send(request);
        return user;
    }
}