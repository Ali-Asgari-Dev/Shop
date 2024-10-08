using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts;
using Shop.Application.Dto.Requests.Orders;

namespace Shop.RestApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class OrderController(IOrderService orderService):ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto dto)
    {
        return Ok(await orderService.CreateOrder(dto));
    }
    [HttpPut("AddItemToOrder")]
    public async Task<IActionResult> AddItemToOrder([FromBody] AddItemToOrderRequestDto dto)
    {
        await orderService.AddItemToOrder(dto);
        return Ok();
    }
    [HttpPut("ApplyDiscount")]
    public async Task<IActionResult> ApplyDiscount([FromBody] OrderApplyDiscountRequestDto dto)
    {
        await orderService.ApplyDiscount(dto);
        return Ok();
    }
    [HttpPut("Paid")]
    public async Task<IActionResult> Paid([FromBody] PaidOrderRequestDto dto)
    {
        await orderService.Paid(dto);
        return Ok();
    }
}