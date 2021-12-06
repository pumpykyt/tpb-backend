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
    public async Task<IActionResult> CreateJobAsync(JobRequest model) =>
        Ok(await Mediator.Send(new CreateJobCommand(model)));

    [HttpDelete]
    public async Task<IActionResult> DeleteJobAsync(int jobId) => 
        Ok(await Mediator.Send(new DeleteJobCommand(jobId)));

    [HttpGet]
    public async Task<IActionResult> GetProjectJobsAsync(int projectId) =>
        Ok(await Mediator.Send(new GetProjectJobsQuery(projectId)));
}