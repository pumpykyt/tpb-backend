using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Commands;
using TeamProject.Application.Queries;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.Controllers;

public sealed class ApplicationController : ApiControllerBase
{
    public ApplicationController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> CreateApplicationAsync(ApplicationRequest model) =>
        Ok(await Mediator.Send(new CreateApplicationCommand(model)));

    [HttpGet]
    public async Task<IActionResult> GetUserApplicationsAsync(string userId) =>
        Ok(await Mediator.Send(new GetUserApplicationsQuery(userId)));

    [HttpDelete]
    public async Task<IActionResult> DeleteApplicationAsync(int applicationId) =>
        Ok(await Mediator.Send(new DeleteApplicationCommand(applicationId)));

    [HttpPut]
    public async Task<IActionResult> AcceptApplicationAsync(int applicationId) =>
        Ok(await Mediator.Send(new AcceptApplicationCommand(applicationId)));

    [HttpPut]
    public async Task<IActionResult> RejectApplicationAsync(int applicationId) =>
        Ok(await Mediator.Send(new RejectApplicationCommand(applicationId)));
}