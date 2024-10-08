namespace Shop.Application.Dto.Responses.Categories;

public class AllCategoryResponseDto(long id,string title, int unitOfDiscountForRepurchase)
{
    public long Id { get;  set; } = id;
    public string Title { get;  set; } = title;
    public int UnitOfDiscountForRepurchase { get;  set; } = unitOfDiscountForRepurchase;
}