using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts;
using Shop.Application.Dto.Requests.Categories;

namespace Shop.RestApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CategoryController(ICategoryService categoryService):ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateCategoryRequestDto dto)
    {
        await categoryService.Create(dto);
        return Ok();
    }
    [HttpGet("All")]
    public async Task<IActionResult> AllProduct()
    {
        return Ok( await categoryService.All());
    }
}