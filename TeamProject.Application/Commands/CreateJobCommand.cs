using MediatR;
using TeamProject.Dto.Requests;

namespace TeamProject.Application.Commands;

public class CreateJobCommand : IRequest<bool>
{
    public JobRequest Data { get; set; }

    public CreateJobCommand(JobRequest data) => Data = data;
}