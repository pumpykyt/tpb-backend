using MediatR;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Queries;

public class GetProjectsQuery : IRequest<PagedResponse<ProjectResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchQuery { get; set; }
    public string? SortQuery { get; set; }

    public GetProjectsQuery(int pageNumber, int pageSize, string? searchQuery, string? sortQuery)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchQuery = searchQuery;
        SortQuery = sortQuery;
    }
}