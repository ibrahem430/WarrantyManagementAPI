using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Warranty;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;


[ApiController]
[Route("api/warranties")]
[Authorize]
public class WarrantiesController(WarrantyService warrantyService) :ControllerBase
{
    [Authorize (Roles ="Admin,Employee")]
      [HttpPost]
    public async Task<IActionResult> AddWarranty(CreateWarrantyRequest request)
    {
      var warranty=await warrantyService.CreateWarrantyAsync(request);
      
       return  CreatedAtRoute("GetWarrantyById",new {warrantyId=warranty.Id},warranty);
       

    }


[Authorize (Roles ="Admin")]
         [HttpDelete("{warrantyId:guid}")]
    public async Task<IActionResult> DeleteWarranty(Guid warrantyId)
    {
      await warrantyService.DeleteWarrantyAsync(warrantyId);
      
       return  NoContent();
       

    }
[Authorize (Roles ="Admin,Employee")]
       [HttpGet("{warrantyId:guid}",Name ="GetWarrantyById")]
    public async Task<IActionResult> GetWarrantyById(Guid warrantyId)
    {
      var warranty=await warrantyService.GetWarrantyAsync(warrantyId);
      
       return  Ok(warranty);
       

    }
[Authorize (Roles ="Admin,Employee")]
       [HttpGet]
    public async Task<IActionResult> GetAllWarranties()
    {
      var warranties=await warrantyService.GetAllWarrantiesAsync();
      
       return  Ok(warranties);
    }
}