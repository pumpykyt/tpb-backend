using MediatR;

namespace TeamProject.Application.Commands;

public class AcceptApplicationCommand : IRequest<bool>
{
    public int ApplicationId { get; set; }

    public AcceptApplicationCommand(int applicationId) => ApplicationId = applicationId;
}