using MediatR;

namespace TeamProject.Application.Commands;

public class RejectApplicationCommand : IRequest<bool>
{
    public int ApplicationId { get; set; }

    public RejectApplicationCommand(int applicationId) => ApplicationId = applicationId;
}