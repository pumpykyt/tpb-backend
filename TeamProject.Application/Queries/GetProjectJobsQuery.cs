using MediatR;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Queries;

public class GetProjectJobsQuery : IRequest<List<JobResponse>>
{
    public int ProjectId { get; set; }

    public GetProjectJobsQuery(int projectId)
    {
        ProjectId = projectId;
    }
}