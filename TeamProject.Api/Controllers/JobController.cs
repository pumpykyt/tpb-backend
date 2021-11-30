using Microsoft.AspNetCore.Mvc;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateJobAsync(JobRequest model)
    {
        var result = await _jobService.CreateJobAsync(model);
        return result == false ? BadRequest() : Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteJobAsync(int jobId)
    {
        var result = await _jobService.DeleteJobAsync(jobId);
        return result == false ? BadRequest() : Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetProjectJobsAsync(int projectId)
    {
        var result = await _jobService.GetProjectJobsAsync(projectId);
        return Ok(result);
    }
}