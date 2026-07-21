using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Login;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route("api/refresh-token")]
public class RefreshTokenController(
    RefreshTokenService refreshTokenService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenRequest request)
    {
        var result =
            await refreshTokenService.RefreshTokenAsync(request);

        return Ok(result);
    }
}