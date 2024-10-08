using Framework.Domain;
using Shop.Domain.Services;

namespace Shop.Domain.Models.Orders;

public class Order : AggregateRoot<Guid>
{
    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        Code = new Random().Next(111111, 999999).ToString();
        State = OrderState.RegisteredState();
        CustomerId = customerId;
    }

    private readonly List<OrderItem> _items = new();
    public ICollection<OrderItem> Items => _items;
    public Guid CustomerId { get; private set; }
    public OrderState State { get; private set; }
    public string Code { get; private set; }
    public int UnitOfDiscount { get; private set; }
    public double TotalPrice => _items.Sum(i => i.Price);
    public double TotalFinalPrice => TotalPrice - ((TotalPrice * UnitOfDiscount) / 100);

    public void ApplyDiscount(IUnitOfDiscountCalculatorDomainService unitOfDiscountCalculatorDomainService)
    {
        if (!State.IsOpen()) throw new BusinessException("وضعیت سفارش برای انجام این کار مجاز نمی باشد");
        UnitOfDiscount = unitOfDiscountCalculatorDomainService.Calculate(CustomerId);
    }

    public void AddItem(long productId, int count, double price)
        => _items.Add(new(productId, count, price, Id));

    public void AddItem(IProductDomainService productDomainService, long productId, int count)
    {
        var price = productDomainService.PriceById(productId);
        AddItem(productId, count, price);
    }


    public void Paid() => State = OrderState.PaidState();
}