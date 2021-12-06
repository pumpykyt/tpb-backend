using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using TeamProject.Application.Extensions;
using TeamProject.Application.Handlers;
using TeamProject.Domain.Configs;
using TeamProject.Data;
using TeamProject.Data.Entities;
using TeamProject.Domain.Hubs;
using TeamProject.Domain.Interfaces;
using TeamProject.Domain.Services;
using TeamProject.Dto.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => 
    lc.WriteTo.Console().WriteTo.File($"log-{DateTime.UtcNow}.txt", rollingInterval: RollingInterval.Day));

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddMediatR(typeof(LoginHandler));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    options => options.UseNpgsql(builder.Configuration["ConnectionString"], 
        b => b.MigrationsAssembly("TeamProject.Api")));
builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters();
    });
builder.Services.AddSingleton<IDictionary<string, UserConnectionRequest>>(opts => 
    new Dictionary<string, UserConnectionRequest>());
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder => {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    })
);

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpException();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseRouting();
app.UseEndpoints(t =>
{
    t.MapHub<ChatHub>("/chat");
});
app.UseAuthorization();
app.MapControllers();
app.Run();