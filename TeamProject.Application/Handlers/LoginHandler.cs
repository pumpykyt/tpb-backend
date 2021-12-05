using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthService _authService;

    public LoginHandler(IAuthService authService) => _authService = authService;
    
    public async Task<LoginResponse?> Handle(LoginCommand request, CancellationToken cancellationToken) 
        => await _authService.LoginAsync(request.Data);
}