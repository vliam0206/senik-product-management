using Domain;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Utils;

public static class GenerateJsonWebTokenString
{
    public static string GenerateJsonWebToken(this Account user, string secretKey, DateTime now)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.SerialNumber ,user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Email),
            new Claim(ClaimTypes.Role, AccountTypeEnum.Customer.ToString())
        };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: now.AddHours(1),
            signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
