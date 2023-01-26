namespace Merchant.Api.Services;

public interface IJwtTokenService
{
    string GenerateToken(string username,string email);
}
