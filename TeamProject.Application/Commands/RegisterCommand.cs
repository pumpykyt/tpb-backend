using MediatR;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Commands;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public RegisterRequest Data { get; set; }

    public RegisterCommand(RegisterRequest data) => Data = data;
}