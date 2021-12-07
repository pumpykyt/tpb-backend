using System;
using System.Collections.Generic;
using System.Linq;
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
using TeamProject.Dto.Responses;

namespace TeamProject.UnitTests.Tests;

public class ProjectServiceTests
{
    private DbContextOptions<DataContext> _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase("TeamProjectDb")
        .Options;

    private IProjectService _projectService;
    private IMapper _mapper;
    private string _userId;
    
    [Test]
    public async Task GetProjectsTest()
    {
        var projects = await _projectService.GetProjectsAsync(1, 1, "", "");
        Assert.NotNull(projects.Data);
        Assert.AreEqual(projects.Data.Count, 1);
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
        Assert.AreEqual(result, true);
    }
    
    [Test]
    public async Task DeleteProjectTest()
    {
        var projectId = 777;
        var result = await _projectService.DeleteProjectAsync(projectId);
        Assert.AreEqual(result, true);
    }

    [Test]
    public async Task UpdateProjectAsync()
    {
        var project2 = new ProjectUpdateRequest
        {
            Id = 888,
            Name = "Project1Updated",
            Description = "Project1Description"
        };
        var result = await _projectService.UpdateProjectAsync(project2);
        Assert.AreEqual(result, true);
    }

    [Test]
    public async Task GetUserProjectsTest()
    {
        var userProjects = await _projectService.GetUserProjectsAsync(_userId);
        Assert.NotNull(userProjects);
        Assert.AreEqual(userProjects.Count, 2);
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
            UserName = "test",
        };
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        _userId = user.Id;
        
        var project = new Project
        {
            Name = "Project1",
            Description = "Project1Description",
            GithubUrl = "Project1Url",
            RoomName = Guid.NewGuid().ToString(),
            OwnerId = user.Id,
            Users = new List<User>{ user }
        };
        
        var project2 = new Project
        {
            Id = 777,
            Name = "Project2",
            Description = "Project2Description",
            GithubUrl = "Project2Url",
            RoomName = Guid.NewGuid().ToString(),
            OwnerId = user.Id,
            Users = new List<User>{ user }
        };
        
        var project3 = new Project
        {
            Id = 888,
            Name = "Project3",
            Description = "Project3Description",
            GithubUrl = "Project3Url",
            RoomName = Guid.NewGuid().ToString(),
            OwnerId = user.Id,
            Users = new List<User>{ user }
        };

        await context.Projects.AddAsync(project);
        await context.Projects.AddAsync(project2);
        await context.Projects.AddAsync(project3);
        await context.SaveChangesAsync();
    }
}