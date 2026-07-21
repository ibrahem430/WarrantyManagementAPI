using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Register;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route("api/register")]
public class RegisterController(RegisterService registered) : ControllerBase
{
   [HttpPost]
public async Task<IActionResult> RegisterAccount(
    [FromBody] RegisterRequest request)
{
    Console.WriteLine($"UserName: {request.UserName}");
    Console.WriteLine($"Email: {request.Email}");
    Console.WriteLine($"Password: {request.Password}");

    var result = await registered.AddUserAsync(request);

    return Ok(result);
}
}