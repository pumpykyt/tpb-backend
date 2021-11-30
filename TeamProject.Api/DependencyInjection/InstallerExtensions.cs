using TeamProject.Domain.Interfaces;

namespace TeamProject.Api.DependencyInjection;

public static class InstallerExtensions
{
    public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        var installers = typeof(IInstaller).Assembly.ExportedTypes
            .Where(t => typeof(IInstaller).IsAssignableFrom(t))
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();
        installers.ForEach(installer => installer.InstallServices(services, configuration));
    }
}