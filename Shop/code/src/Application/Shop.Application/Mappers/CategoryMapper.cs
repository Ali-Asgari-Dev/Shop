using Shop.Application.Dto.Requests.Categories;
using Shop.Application.Dto.Responses.Categories;
using Shop.Domain.Models.Categories;

namespace Shop.Application.Mappers;

public static class CategoryMapper
{
    public static Category Factory(this CreateCategoryRequestDto dto) =>
        new(dto.Title, dto.UnitOfDiscountForRepurchase);

    public static List<AllCategoryResponseDto> ToAllCategoryResponseDto(this List<Category> categories) =>
        categories.Select(c=>new AllCategoryResponseDto(c.Id,c.Title,c.UnitOfDiscountForRepurchase)).ToList();
}