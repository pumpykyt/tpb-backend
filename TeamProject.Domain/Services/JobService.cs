using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Data;
using TeamProject.Domain.Data.Entities;
using TeamProject.Domain.Exceptions;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Services;

public class JobService : IJobService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public JobService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> CreateJobAsync(JobRequest model)
    {
        var entity = _mapper.Map<JobRequest, Job>(model);
        await _context.Jobs.AddAsync(entity);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<bool> DeleteJobAsync(int jobId)
    {
        var entity = await _context.Jobs.SingleOrDefaultAsync(t => t.Id == jobId);
        if (entity == null) throw new HttpException(HttpStatusCode.NotFound);
        _context.Jobs.Remove(entity);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }

    public async Task<List<JobResponse>> GetProjectJobsAsync(int projectId)
    {
        var entities = await _context.Jobs.AsNoTracking()
                                          .Include(t => t.User)
                                          .Where(t => t.ProjectId == projectId)
                                          .ToListAsync();
        
        return _mapper.Map<List<Job>, List<JobResponse>>(entities);
    }
}