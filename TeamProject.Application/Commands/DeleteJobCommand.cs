using MediatR;

namespace TeamProject.Application.Commands;

public class DeleteJobCommand : IRequest<bool>
{
    public int JobId { get; set; }

    public DeleteJobCommand(int jobId) => JobId = jobId;
}