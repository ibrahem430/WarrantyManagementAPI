using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Login;
using WarrantyManagement.Application.Responses.RefreshToken;

namespace WarrantyManagement.Application.Services;

public class RefreshTokenService(IConfiguration configuration ,IloginRepository repository)
{
     public async Task<RefreshTokenResponse> RefreshTokenAsync(
    RefreshTokenRequest request)
{
    var user = await repository.GetRefreshToken(
        request.RefreshJWTToken);

    if (user is null)
    {
        throw new KeyNotFoundException(
            "Invalid refresh token.");
    }

    var refreshToken=Guid.NewGuid();

    user.ChangeRefreshToken(refreshToken);

    await repository.UpdateRefreshTokenAsync();

    var claims = new List<Claim>
    {
        new(
            JwtRegisteredClaimNames.Sub,
            user.Id.ToString()),

        new(
            JwtRegisteredClaimNames.Name,
            user.UserName),

        new(
            JwtRegisteredClaimNames.Email,
            user.Email),

        new(
            ClaimTypes.Role,
            user.Role.ToString()),

        new(
            JwtRegisteredClaimNames.Jti,
            refreshToken.ToString())
    };

    var jwtSettings =
        configuration.GetSection("jwtInformation");

    var issuer = jwtSettings["Issuer"]!;
    var audience = jwtSettings["Audience"]!;
    var key = jwtSettings["Key"]!;

    var expires = DateTime.UtcNow.AddMinutes(
        int.Parse(
            jwtSettings["TokenExpirationInMinutes"]!));

    var tokenDescriptor =
        new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expires,
            Issuer = issuer,
            Audience = audience,

            SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256Signature)
        };

    var tokenHandler =
        new JwtSecurityTokenHandler();

    var token =
        tokenHandler.CreateToken(tokenDescriptor);

    return new RefreshTokenResponse
    {
        AccessToken =
            tokenHandler.WriteToken(token),

        RefreshToken =
            refreshToken,

        Expires = expires
    };
}
}