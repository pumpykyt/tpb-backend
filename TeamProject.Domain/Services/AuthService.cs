using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TeamProject.Domain.Configs;
using TeamProject.Domain.Data;
using TeamProject.Domain.Data.Entities;
using TeamProject.Domain.Exceptions;
using TeamProject.Domain.Interfaces;
using TeamProject.Dto.Requests;
using TeamProject.Dto.Responses;

namespace TeamProject.Domain.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly JwtConfig _jwtConfig;

    public AuthService(UserManager<User> userManager, IOptions<JwtConfig> options)
    {
        _userManager = userManager;
        _jwtConfig = options.Value;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) throw new HttpException(HttpStatusCode.BadRequest);
        
        var result = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!result) throw new HttpException(HttpStatusCode.BadRequest);
  
        return new LoginResponse
        {
            Token = GenerateToken(user.Id)
        };
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest model)
    {
        var user = new User
        {
            Email = model.Email,
            UserName = model.UserName
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded) throw new HttpException(HttpStatusCode.BadRequest);
 
        return new RegisterResponse
        {
            Success = true
        };
    }
    
    private string GenerateToken(string userId)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("id", userId)
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience,
            SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}