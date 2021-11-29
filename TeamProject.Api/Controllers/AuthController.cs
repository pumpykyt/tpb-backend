using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest model)
    {
        var result = await _authService.LoginAsync(model);
        return result == null ? BadRequest() : Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest model)
    {
        var result = await _authService.RegisterAsync(model);
        return result == null ? BadRequest() : Ok(result);
    }
}