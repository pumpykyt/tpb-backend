using MediatR;
using TeamProject.Application.Commands;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Application.Handlers;

public class DeleteJobHandler : IRequestHandler<DeleteJobCommand, bool>
{
    private readonly IJobService _jobService;

    public DeleteJobHandler(IJobService jobService) => _jobService = jobService;

    public async Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken) 
        => await _jobService.DeleteJobAsync(request.JobId);
}