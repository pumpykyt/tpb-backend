using MediatR;
using TeamProject.Dto.Requests;

namespace TeamProject.Application.Commands;

public class UpdateProjectCommand : IRequest<bool>
{
    public ProjectUpdateRequest Data { get; set; }

    public UpdateProjectCommand(ProjectUpdateRequest data) => Data = data;
}