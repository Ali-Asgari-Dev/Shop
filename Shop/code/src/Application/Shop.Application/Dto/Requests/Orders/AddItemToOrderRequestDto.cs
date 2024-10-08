namespace Shop.Application.Dto.Requests.Orders;

public class AddItemToOrderRequestDto
{
    public Guid Id { get; set; }
    public long ProductId { get; set; }
    public int Count { get; set; }
}