using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, bool>
{
    private readonly IProjectService _projectService;
    
    public CreateProjectHandler(IProjectService projectService) => _projectService = projectService;

    public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken) 
        => await _projectService.CreateProjectAsync(request.Data);
}