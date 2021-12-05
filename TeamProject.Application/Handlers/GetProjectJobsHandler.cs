using MediatR;
using TeamProject.Application.Queries;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Handlers;

public class GetProjectJobsHandler : IRequestHandler<GetProjectJobsQuery, List<JobResponse>>
{
    private readonly IJobService _jobService;

    public GetProjectJobsHandler(IJobService jobService) => _jobService = jobService;

    public async Task<List<JobResponse>> Handle(GetProjectJobsQuery request, CancellationToken cancellationToken) 
        => await _jobService.GetProjectJobsAsync(request.ProjectId);
}