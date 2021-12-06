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
    public async Task<IActionResult> CreateProjectAsync(ProjectRequest model) =>
        Ok(await Mediator.Send(new CreateProjectCommand(model)));

    [HttpPut]
    public async Task<IActionResult> UpdateProjectAsync(ProjectUpdateRequest model) =>
        Ok(await Mediator.Send(new UpdateProjectCommand(model)));

    [HttpDelete]
    public async Task<IActionResult> DeleteProjectAsync(int projectId) => 
        Ok(await Mediator.Send(new DeleteProjectCommand(projectId)));

    [HttpGet]
    public async Task<IActionResult> GetProjectsAsync(int pageNumber, int pageSize, 
                                                      string? searchQuery, string? sortQuery) =>
        Ok(await Mediator.Send(new GetProjectsQuery(pageNumber, pageSize, searchQuery, sortQuery)));

    [HttpGet("user")]
    public async Task<IActionResult> GetUserProjectsAsync(string userId) =>
        Ok(await Mediator.Send(new GetUserProjectsQuery(userId)));
}