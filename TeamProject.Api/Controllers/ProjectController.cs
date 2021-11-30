using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync(ProjectRequest model)
    {
        var result = await _projectService.CreateProjectAsync(model);
        return result == false ? BadRequest() : Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProjectAsync(ProjectUpdateRequest model)
    {
        var result = await _projectService.UpdateProjectAsync(model);
        return result == false ? BadRequest() : Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteProjectAsync(int projectId)
    {
        var result = await _projectService.DeleteProjectAsync(projectId);
        return result == false ? BadRequest() : Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProjectsAsync(int pageNumber, int pageSize, string? searchQuery, string? sortQuery)
    {
        var result = await _projectService.GetProjectsAsync(pageNumber, pageSize, searchQuery, sortQuery);
        return Ok(result);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUserProjectsAsync(string userId)
    {
        var result = await _projectService.GetUserProjectsAsync(userId);
        return Ok(result);
    }
}