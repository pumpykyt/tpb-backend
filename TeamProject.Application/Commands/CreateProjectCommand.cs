using MediatR;
using TeamProject.Dto.Requests;

namespace TeamProject.Application.Commands;

public class CreateProjectCommand : IRequest<bool>
{
    public ProjectRequest Data { get; set; }

    public CreateProjectCommand(ProjectRequest data) => Data = data;
}