using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Warranty;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;


[ApiController]
[Route("api/warranties")]

public class WarrantiesController(WarrantyService warrantyService) :ControllerBase
{
      [HttpPost]
    public async Task<IActionResult> AddWarranty(CreateWarrantyRequest request)
    {
      var warranty=await warrantyService.CreateWarrantyAsync(request);
      
       return  CreatedAtRoute("GetWarrantyById",new {warrantyId=warranty.Id},warranty);
       

    }



         [HttpDelete("{warrantyId:guid}")]
    public async Task<IActionResult> DeleteWarranty(Guid warrantyId)
    {
      await warrantyService.DeleteWarrantyAsync(warrantyId);
      
       return  NoContent();
       

    }

       [HttpGet("{warrantyId:guid}",Name ="GetWarrantyById")]
    public async Task<IActionResult> GetWarrantyById(Guid warrantyId)
    {
      var warranty=await warrantyService.GetWarrantyAsync(warrantyId);
      
       return  Ok(warranty);
       

    }

       [HttpGet]
    public async Task<IActionResult> GetAllWarranties()
    {
      var warranties=await warrantyService.GetAllWarrantiesAsync();
      
       return  Ok(warranties);
    }
}