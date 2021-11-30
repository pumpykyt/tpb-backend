using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TeamProject.Domain.Configs;
using TeamProject.Domain.Data;
using TeamProject.Domain.Data.Entities;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;

namespace TeamProject.Api.DependencyInjection;

public class DataInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSignalR();
        services.AddEndpointsApiExplorer();
        services.AddAutoMapper(typeof(MapperConfig));
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(
            options => options.UseNpgsql(configuration["ConnectionString"], 
                b => b.MigrationsAssembly("TeamProject.Api")));
        services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters();
            });
        services.AddSingleton<IDictionary<string, UserConnectionRequest>>(opts => 
            new Dictionary<string, UserConnectionRequest>());
        services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder => {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
            })
        );
    }
}