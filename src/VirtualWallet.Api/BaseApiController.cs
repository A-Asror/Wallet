using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VirtualWallet.WebApi;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;

    // Protected property to lazily initialize the IMediator instance using the service provider
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}