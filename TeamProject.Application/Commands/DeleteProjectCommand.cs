using MediatR;

namespace TeamProject.Application.Commands;

public class DeleteProjectCommand : IRequest<bool>
{
    public int ProjectId { get; set; }

    public DeleteProjectCommand(int projectId) => ProjectId = projectId;
}