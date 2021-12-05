using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Commands;
using TeamProject.Application.Queries;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

public sealed class ProjectController : ApiControllerBase
{
    public ProjectController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync(ProjectRequest model)
    {
        var command = new CreateProjectCommand(model);
        var result = await Mediator.Send(command);
        return result == false ? BadRequest() : Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProjectAsync(ProjectUpdateRequest model)
    {

        var command = new UpdateProjectCommand(model);
        var result = await Mediator.Send(command);
        return result == false ? BadRequest() : Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteProjectAsync(int projectId)
    {
        var command = new DeleteProjectCommand(projectId);
        var result = await Mediator.Send(command);
        return result == false ? BadRequest() : Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProjectsAsync(int pageNumber, int pageSize, string? searchQuery, string? sortQuery)
    {
        var query = new GetProjectsQuery(pageNumber, pageSize, searchQuery, sortQuery);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUserProjectsAsync(string userId)
    {
        var query = new GetUserProjectsQuery(userId);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}