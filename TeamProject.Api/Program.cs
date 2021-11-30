using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TeamProject.Api.DependencyInjection;
using TeamProject.Domain.Configs;
using TeamProject.Domain.Data;
using TeamProject.Domain.Data.Entities;
using TeamProject.Domain.Hubs;
using TeamProject.Domain.Interfaces;
using TeamProject.Domain.Services;
using TeamProject.Dto.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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