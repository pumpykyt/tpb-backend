using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IMediator Mediator;

    public ApiControllerBase(IMediator mediator) => Mediator = mediator ?? throw new ArgumentNullException();
}