using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamProject.Data;
using TeamProject.Data.Entities;
using TeamProject.Domain.Exceptions;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Services;

public class ProjectService : IProjectService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProjectService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> CreateProjectAsync(ProjectRequest model)
    {
        var entity = _mapper.Map<ProjectRequest, Project>(model);
        entity.RoomName = Guid.NewGuid()
                              .ToString();
        await _context.Projects.AddAsync(entity);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<PagedResponse<ProjectResponse>> GetProjectsAsync(int pageNumber, int pageSize, 
        string searchQuery, string sortQuery)
    {
        var entities = _context.Projects.AsNoTracking()
                                        .AsQueryable();

        if (!string.IsNullOrEmpty(searchQuery))
        {
            entities = entities.Where(t => t.Name.ToLower().Contains(searchQuery.ToLower()));
        }

        switch (sortQuery)
        {
            case "name_asc":
                entities = entities.OrderBy(t => t.Name);
                break;
            case "name_desc":
                entities = entities.OrderByDescending(t => t.Name);
                break;
            default: 
                break;
        }

        var projects = await entities.Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();

        var result = _mapper.Map<List<Project>, List<ProjectResponse>>(projects);
        
        return new PagedResponse<ProjectResponse>(result, pageNumber, pageSize);
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateRequest model)
    {
        var entity = _mapper.Map<ProjectUpdateRequest, Project>(model);
        if (entity == null) throw new HttpException(HttpStatusCode.NotFound);
        _context.Projects.Update(entity);
        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        var entity = await _context.Projects.SingleOrDefaultAsync(t => t.Id == projectId);
        if (entity == null) throw new HttpException(HttpStatusCode.NotFound);
        _context.Projects.Remove(entity);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }

    public async Task<List<ProjectResponse>> GetUserProjectsAsync(string userId)
    {
        var user = await _context.Users.AsNoTracking()
                                       .Include(t => t.Projects)
                                       .SingleOrDefaultAsync(t => t.Id == userId);
        
        return _mapper.Map<List<Project>, List<ProjectResponse>>(user.Projects.ToList());
    }
}