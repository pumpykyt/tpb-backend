using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TeamProject.Data;
using TeamProject.Data.Entities;
using TeamProject.Domain.Configs;
using TeamProject.Domain.Interfaces;
using TeamProject.Domain.Services;
using TeamProject.Dto.Requests;

namespace TeamProject.UnitTests.Tests;

public class ProjectServiceTests
{
    private DbContextOptions<DataContext> _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase("TeamProjectDb")
        .Options;

    private IProjectService _projectService;
    private IMapper _mapper;
    
    [Test]
    public async Task GetProjectsTest()
    {
        var projects = await _projectService.GetProjectsAsync(1, 1, "", "");
        projects.Data.Should().NotBeNull();
        projects.Data.Count.Should().Be(1);
    }

    [Test]
    public async Task CreateProjectTest()
    {
        var project = new ProjectRequest
        {
            Name = "Project1",
            Description = "Project1Description",
            GithubUrl = "Project1Url",
            RoomName = Guid.NewGuid().ToString(),
            OwnerId = Guid.NewGuid().ToString()
        };

        var result = await _projectService.CreateProjectAsync(project);

        result.Should().BeTrue();
    }

    [OneTimeSetUp]
    public async Task Setup()
    {
        await SeedDb();
        
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperConfig());
        });
        
        _mapper = mockMapper.CreateMapper();
        _projectService = new ProjectService(new DataContext(_dbContextOptions), _mapper);
    }

    public async Task SeedDb()
    {
        using var context = new DataContext(_dbContextOptions);

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = "test@gmail.com",
            UserName = "test"
        };
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        var project = new Project
        {
            Name = "Project1",
            Description = "Project1Description",
            GithubUrl = "Project1Url",
            RoomName = Guid.NewGuid().ToString(),
            OwnerId = user.Id
        };

        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();
    }
}