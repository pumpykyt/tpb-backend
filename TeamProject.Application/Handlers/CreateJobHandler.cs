using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class CreateJobHandler : IRequestHandler<CreateJobCommand, bool>
{
    private readonly IJobService _jobService;

    public CreateJobHandler(IJobService jobService) => _jobService = jobService;

    public async Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken) 
        => await _jobService.CreateJobAsync(request.Data);
}