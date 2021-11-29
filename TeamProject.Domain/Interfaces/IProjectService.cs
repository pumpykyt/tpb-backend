using System.Threading.Tasks;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRequest model);
    Task<PagedResponse<ProjectResponse>> GetProjectsAsync(int pageNumber, int pageSize, string searchQuery, string sortQuery);
    Task<bool> UpdateProjectAsync(ProjectUpdateRequest model);
    Task<bool> DeleteProjectAsync(int projectId);
}