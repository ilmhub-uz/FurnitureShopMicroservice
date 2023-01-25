namespace Identity.Api.Services;

public interface IJwtTokenService
{
    string GenerateToken(string username);
}