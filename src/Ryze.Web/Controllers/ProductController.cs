using Microsoft.AspNetCore.Mvc;
using Ryze.Application.Services.Product.CreateProduct;
using Ryze.Application.Services.Product.CreateProduct.Dto;

namespace Ryze.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDtoRequest request, [FromServices] CreateProductService service)
    {
        await service.CreateProduct(request);
        
        return Created("", null);
    }
}