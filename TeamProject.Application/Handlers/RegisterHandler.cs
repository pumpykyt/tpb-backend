using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Handlers;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IAuthService _authService;

    public RegisterHandler(IAuthService authService) => _authService = authService;

    public async Task<RegisterResponse?> Handle(RegisterCommand request, CancellationToken cancellationToken)
        => await _authService.RegisterAsync(request.Data);
}