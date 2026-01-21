using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CourseWork.Entities;
using CourseWork.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CourseWork.Services;

public class JwtService(IOptions<AuthSettings> options)
{
    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("userName", user.UserName),
            new Claim("firstName", user.FirstName),
            new Claim("password", user.Password),
            new Claim("role", user.Role)
        };

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(options.Value.Expires),
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}