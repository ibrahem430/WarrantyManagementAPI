using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Login;

namespace WarrantyManagement.Application.Services;

public class LogoutService(IloginRepository repository)
{
    public async Task LogoutAsync(
        RefreshTokenRequest request)
    {
        var foundUser =
            await repository.GetRefreshToken(
                request.RefreshJWTToken);

        if (foundUser is null)
        {
            throw new KeyNotFoundException(
                "Invalid refresh token.");
        }

       foundUser.RevokeRefreshToken();

        await repository.UpdateRefreshTokenAsync();
    }
}

