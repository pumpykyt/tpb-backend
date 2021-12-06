using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class RejectApplicationHandler : IRequestHandler<RejectApplicationCommand, bool>
{
    private readonly IApplicationService _applicationService;

    public RejectApplicationHandler(IApplicationService applicationService) => 
        _applicationService = applicationService;

    public async Task<bool> Handle(RejectApplicationCommand request, CancellationToken cancellationToken) => 
        await _applicationService.RejectApplicationAsync(request.ApplicationId);
}