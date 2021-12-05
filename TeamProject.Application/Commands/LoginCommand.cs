using MediatR;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Application.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public LoginRequest Data { get; set; }

    public LoginCommand(LoginRequest data) => Data = data;
}