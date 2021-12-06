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
    public async Task<IActionResult> LoginAsync(LoginRequest model) => 
        Ok(await Mediator.Send(new LoginCommand(model)));

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest model) =>
        Ok(await Mediator.Send(new RegisterCommand(model)));
}