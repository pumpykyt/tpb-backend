using MediatR;

namespace TeamProject.Application.Commands;

public class DeleteApplicationCommand : IRequest<bool>
{
    public int ApplicationId { get; set; }

    public DeleteApplicationCommand(int applicationId) => ApplicationId = applicationId;
}