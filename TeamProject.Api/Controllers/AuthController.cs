using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

public sealed class AuthController : ApiControllerBase
{
    public AuthController(IMediator mediator) : base(mediator) { }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest model)
    {
        var command = new LoginCommand(model);
        var result = await Mediator.Send(command);
        return result == null ? BadRequest() : Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest model)
    {
        var command = new RegisterCommand(model);
        var result = await Mediator.Send(command);
        return result == null ? BadRequest() : Ok(result);
    }
}