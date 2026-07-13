using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Products;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route ("api/product")]

public class ProductsController(ProductService productService):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductRequest request)
    {
      var product=await productService.CreateProductAsync(request);
      
       return  NoContent();
       

    }
}