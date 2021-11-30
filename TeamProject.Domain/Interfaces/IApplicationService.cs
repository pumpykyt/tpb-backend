using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Interfaces;

public interface IApplicationService
{
    Task<bool> CreateApplicationAsync(ApplicationRequest model);
    Task<List<ApplicationResponse>> GetUserApplicationsAsync(string userId);
    Task<bool> DeleteApplicationAsync(int applicationId);
}