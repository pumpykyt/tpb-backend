using MediatR;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Queries;

public class GetUserApplicationsQuery : IRequest<List<ApplicationResponse>>
{
    public string UserId { get; set; }

    public GetUserApplicationsQuery(string userId) => UserId = userId;
}