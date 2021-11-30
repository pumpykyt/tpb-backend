using TeamProject.Domain.Interfaces;
using TeamProject.Domain.Services;

namespace TeamProject.Api.DependencyInjection;

public class ScopedServicesInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IProjectService, ProjectService>();
    }
}