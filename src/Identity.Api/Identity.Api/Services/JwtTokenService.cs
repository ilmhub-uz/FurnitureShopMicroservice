using Identity.Api.Options;
using JFA.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Api.Services;

[Scoped]
public class JwtTokenService : IJwtTokenService
{
    private readonly JwtTokenValidationParameters _validationParameters;

    public JwtTokenService(IOptions<JwtTokenValidationParameters> validationParameters)
    {
        _validationParameters = validationParameters.Value;
    }

    public string GenerateToken(string username)
    {
        var keyByte = System.Text.Encoding.UTF8.GetBytes(_validationParameters.IssuerSigningKey);
        var securityKey = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);

        var security = new JwtSecurityToken(
            issuer: _validationParameters.ValidIssuer,
            audience: _validationParameters.ValidAudience,
            new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            },
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: securityKey);

        return new JwtSecurityTokenHandler().WriteToken(security);
    }
}