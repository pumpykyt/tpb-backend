using System.Diagnostics;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TeamProject.Data;
using TeamProject.Data.Entities;
using TeamProject.Domain.Exceptions;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Services;

public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly ILogger<ApplicationService> _logger;

    public ApplicationService(IMapper mapper, DataContext context, ILogger<ApplicationService> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateApplicationAsync(ApplicationRequest model)
    {
        var entity = _mapper.Map<ApplicationRequest, Application>(model);
        entity.Status = "Pending";
        await _context.Applications.AddAsync(entity);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<List<ApplicationResponse>> GetUserApplicationsAsync(string userId)
    {
        var userExists = await _context.Users.AnyAsync(t => t.Id == userId);
        if (!userExists) throw new HttpException(HttpStatusCode.NotFound);
        
        var entities = await _context.Applications.AsNoTracking()
                                                  .Where(t => t.UserId == userId)
                                                  .ToListAsync();

        return _mapper.Map<List<Application>, List<ApplicationResponse>>(entities);
    }

    public async Task<bool> DeleteApplicationAsync(int applicationId)
    {
        var entity = await _context.Applications.SingleOrDefaultAsync(t => t.Id == applicationId);
        if (entity == null) throw new HttpException(HttpStatusCode.NotFound);
        _context.Applications.Remove(entity);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }

    public async Task<bool> AcceptApplicationAsync(int applicationId)
    {
        var application = await _context.Applications.SingleOrDefaultAsync(t => t.Id == applicationId);
        if (application == null) throw new HttpException(HttpStatusCode.NotFound);
        application.Status = "Accepted";
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == application.UserId);
        var project = await _context.Projects.SingleOrDefaultAsync(t => t.Id == application.ProjectId);
        project.Users.Add(user);
        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<bool> RejectApplicationAsync(int applicationId)
    {
        var application = await _context.Applications.SingleOrDefaultAsync(t => t.Id == applicationId);
        if (application == null) throw new HttpException(HttpStatusCode.NotFound);
        application.Status = "Rejected";
        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }
}