using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Login;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route("api/logout")]
public class LogoutController(LogoutService service):ControllerBase
{

[HttpPost]
 public async Task<IActionResult> Logout(RefreshTokenRequest request)
    {
        await service.LogoutAsync(request);
        return  Ok();
    }
}