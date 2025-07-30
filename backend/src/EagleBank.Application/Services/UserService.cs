using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EagleBank.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string AuthorizeUser(LoginUserRequest request)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hM3b8nIUQFPBV9FMasFwAD3X89nvzuOs"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Email),
        };

        var token = new JwtSecurityToken(
            issuer: "EagleBank",
            audience: "EagleBank",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
    {
        var user = User.CreateUser(request.FirstName, request.LastName, request.Email);
        user = await _userRepository.AddUserAsync(user);
        return UserDto.FromEntity(user);
    }
}