using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TeamProject.Domain.Interfaces;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}