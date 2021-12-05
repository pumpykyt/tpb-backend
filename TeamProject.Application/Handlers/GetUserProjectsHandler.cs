using MediatR;
using TeamProject.Application.Queries;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Handlers;

public class GetUserProjectsHandler : IRequestHandler<GetUserProjectsQuery, List<ProjectResponse>>
{
    private readonly IProjectService _projectService;
    
    public GetUserProjectsHandler(IProjectService projectService) => _projectService = projectService;

    public async Task<List<ProjectResponse>> Handle(GetUserProjectsQuery request, CancellationToken cancellationToken) 
        => await _projectService.GetUserProjectsAsync(request.UserId);
}