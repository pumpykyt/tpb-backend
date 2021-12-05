using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Commands;
using TeamProject.Application.Queries;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

public sealed class JobController : ApiControllerBase
{
    public JobController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> CreateJobAsync(JobRequest model)
    {
        var command = new CreateJobCommand(model);
        var result = await Mediator.Send(command);
        return result == false ? BadRequest() : Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteJobAsync(int jobId)
    {
        var command = new DeleteJobCommand(jobId);
        var result = await Mediator.Send(command);
        return result == false ? BadRequest() : Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetProjectJobsAsync(int projectId)
    {
        var query = new GetProjectJobsQuery(projectId);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}