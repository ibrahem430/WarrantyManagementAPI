using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Sales;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;


[ApiController]
[Route("api/sales")]

public class SalesController(SaleService saleService):ControllerBase
{
      [HttpPost]
    public async Task<IActionResult> AddSale(CreateSaleRequest request)
    {
      var sale=await saleService.CreateSaleAsync(request);
      
       return  CreatedAtRoute("GetSaleById",new {saleId=sale.Id},sale);
       

    }

     [HttpPut]
    public async Task<IActionResult> UpdateSale(UpdateSaleRequest request)
    {
     await saleService.UpdateSaleAsync(request);
      
       return  NoContent();
       

    }

         [HttpDelete("{saleId:guid}")]
    public async Task<IActionResult> DeleteSale(Guid saleId)
    {
      await saleService.DeleteSaleAsync(saleId);
      
       return  NoContent();
       

    }

       [HttpGet("{saleId:guid}",Name ="GetSaleById")]
    public async Task<IActionResult> GetSaleById(Guid saleId)
    {
      var sale=await saleService.GetSaleAsync(saleId);
      
       return  Ok(sale);
       

    }

       [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
      var sales=await saleService.GetAllSalesAsync();
      
       return  Ok(sales);
    }
}