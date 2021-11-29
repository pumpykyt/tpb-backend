using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest model);
    Task<RegisterResponse> RegisterAsync(RegisterRequest model);
}