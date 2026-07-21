using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Products;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route ("api/product")]
[Authorize]
public class CustomersController(ProductService productService):ControllerBase
{
 
[Authorize (Roles ="Admin,Employee")]
    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductRequest request)
    {
      var product=await productService.CreateProductAsync(request);
      
       return  CreatedAtRoute("GetProductById",new {productId=product.Id},product);
       

    }
[Authorize (Roles ="Admin")]
     [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
     await productService.UpdateProductAsync(request);
      
       return  NoContent();
       

    }
[Authorize (Roles ="Admin")]
         [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
      await productService.DeleteProductAsync(productId);
      
       return  NoContent();
       

    }
[Authorize (Roles ="Admin,Employee,User")]
       [HttpGet("{ProductId:guid}",Name ="GetProductById")]
    public async Task<IActionResult> GetProductById(Guid ProductId)
    {
      var product=await productService.GetProductAsync(ProductId);
      
       return  Ok(product);
       

    }
[Authorize (Roles ="Admin,Employee,User")]
       [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
      var products=await productService.GetAllProductAsync();
      
       return  Ok(products);
    }
}