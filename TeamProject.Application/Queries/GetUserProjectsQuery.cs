using MediatR;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Queries;

public class GetUserProjectsQuery : IRequest<List<ProjectResponse>>
{
    public string UserId { get; set; }

    public GetUserProjectsQuery(string userId) => UserId = userId;
}