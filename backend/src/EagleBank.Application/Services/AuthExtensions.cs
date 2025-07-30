using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EagleBank.Application.Services;

public static class AuthExtensions
{
    public static string GetToken(string email)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hM3b8nIUQFPBV9FMasFwAD3X89nvzuOs"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, email),
        };

        var token = new JwtSecurityToken(
            issuer: "EagleBank",
            audience: "EagleBank",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
}