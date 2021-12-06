using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, bool>
{
    private readonly IApplicationService _applicationService;

    public CreateApplicationHandler(IApplicationService applicationService) => 
        _applicationService = applicationService;

    public async Task<bool> Handle(CreateApplicationCommand request, CancellationToken cancellationToken) =>
        await _applicationService.CreateApplicationAsync(request.Data);
}