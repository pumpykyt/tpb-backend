using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class DeleteApplicationHandler : IRequestHandler<DeleteApplicationCommand, bool>
{
    private readonly IApplicationService _applicationService;

    public DeleteApplicationHandler(IApplicationService applicationService) => 
        _applicationService = applicationService;

    public async Task<bool> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken) =>
        await _applicationService.DeleteApplicationAsync(request.ApplicationId);
}