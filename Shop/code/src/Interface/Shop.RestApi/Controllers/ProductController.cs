using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts;
using Shop.Application.Dto.Requests.Products;

namespace Shop.RestApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductController(IProductService productService):ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto dto)
    {
        await productService.CreateProduct(dto);
        return Ok();
    }
    [HttpGet("All")]
    public async Task<IActionResult> AllProduct()
    {
        return Ok( await productService.All());
    }
}