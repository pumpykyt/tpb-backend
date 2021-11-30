using Microsoft.Extensions.DependencyInjection;
using TeamProject.Domain.Configs;
using TeamProject.Domain.Interfaces;

namespace TeamProject.Api.DependencyInjection;

public class ConfigInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
    }
}