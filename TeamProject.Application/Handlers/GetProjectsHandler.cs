using MediatR;
using TeamProject.Application.Queries;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Handlers;

public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, PagedResponse<ProjectResponse>>
{
    private readonly IProjectService _projectService;
    
    public GetProjectsHandler(IProjectService projectService) => _projectService = projectService;

    public async Task<PagedResponse<ProjectResponse>> Handle(GetProjectsQuery request, CancellationToken cancellationToken) 
        => await _projectService.GetProjectsAsync(request.PageNumber, request.PageSize, 
                                                  request.SearchQuery, request.SortQuery);
}