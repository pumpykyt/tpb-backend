using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, bool>
{
    private readonly IProjectService _projectService;
    
    public UpdateProjectHandler(IProjectService projectService) => _projectService = projectService;

    public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken) 
        => await _projectService.UpdateProjectAsync(request.Data);
}