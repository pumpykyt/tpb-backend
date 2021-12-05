using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, bool>
{
    private readonly IProjectService _projectService;
    
    public DeleteProjectHandler(IProjectService projectService) => _projectService = projectService;

    public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        => await _projectService.DeleteProjectAsync(request.ProjectId);
}