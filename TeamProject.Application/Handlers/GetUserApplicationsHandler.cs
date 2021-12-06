using MediatR;
using TeamProject.Application.Queries;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Handlers;

public class GetUserApplicationsHandler : IRequestHandler<GetUserApplicationsQuery, List<ApplicationResponse>>
{
    private readonly IApplicationService _applicationService;

    public GetUserApplicationsHandler(IApplicationService applicationService) => 
        _applicationService = applicationService;

    public async Task<List<ApplicationResponse>> Handle(GetUserApplicationsQuery request,
        CancellationToken cancellationToken) => await _applicationService.GetUserApplicationsAsync(request.UserId);
}