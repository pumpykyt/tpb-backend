using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Data;
using TeamProject.Domain.Data.Entities;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Services;

public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ApplicationService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> CreateApplicationAsync(ApplicationRequest model)
    {
        var entity = _mapper.Map<ApplicationRequest, Application>(model);
        await _context.Applications.AddAsync(entity);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<List<ApplicationResponse>> GetUserApplicationsAsync(string userId)
    {
        var entities = await _context.Applications.AsNoTracking()
                                                  .Where(t => t.UserId == userId)
                                                  .ToListAsync();

        return _mapper.Map<List<Application>, List<ApplicationResponse>>(entities);
    }

    public async Task<bool> DeleteApplicationAsync(int applicationId)
    {
        var entity = await _context.Applications.SingleOrDefaultAsync(t => t.Id == applicationId);
        _context.Applications.Remove(entity);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
}