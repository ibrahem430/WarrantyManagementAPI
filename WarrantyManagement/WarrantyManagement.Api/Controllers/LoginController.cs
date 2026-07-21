// using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Login;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route ("api/login")]

public class LoginController(LoginService service):ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result=await service.LoginUserAsync(request);
         return Ok(result);

    }
    // [HttpPost]
    //  public async Task<IActionResult> Login(LoginRequest request)
    // {
    //     var result=await service.LoginUserAsync(request);
    //      return Ok(result);

    // }

}