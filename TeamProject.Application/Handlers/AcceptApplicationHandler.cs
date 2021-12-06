using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class AcceptApplicationHandler : IRequestHandler<AcceptApplicationCommand, bool>
{
    private readonly IApplicationService _applicationService;

    public AcceptApplicationHandler(IApplicationService applicationService) => 
        _applicationService = applicationService;

    public async Task<bool> Handle(AcceptApplicationCommand request, CancellationToken cancellationToken) =>
        await _applicationService.AcceptApplicationAsync(request.ApplicationId);
}