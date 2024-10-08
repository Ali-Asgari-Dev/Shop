using Shop.Application.Dto.Requests.Orders;
using Shop.Domain.Models.Orders;

namespace Shop.Application.Mappers;

public static class OrderMapper
{
    public static Order Factory(this CreateOrderRequestDto dto)=>new Order(dto.CustomerId);
}