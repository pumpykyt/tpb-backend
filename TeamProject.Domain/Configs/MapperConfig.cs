using AutoMapper;
using TeamProject.Domain.Data.Entities;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Configs;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ProjectRequest, Project>();
        CreateMap<ProjectUpdateRequest, Project>();
        CreateMap<Project, ProjectResponse>();
    }
}