using MediatR;
using TeamProject.Dto.Requests;

namespace TeamProject.Application.Commands;

public class CreateApplicationCommand : IRequest<bool>
{
    public ApplicationRequest Data { get; set; }

    public CreateApplicationCommand(ApplicationRequest data) => Data = data;
}