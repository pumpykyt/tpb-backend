using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Interfaces;

public interface IJobService
{
    Task<bool> CreateJobAsync(JobRequest model);
    Task<bool> DeleteJobAsync(int jobId);
    Task<List<JobResponse>> GetProjectJobsAsync(int projectId);
}