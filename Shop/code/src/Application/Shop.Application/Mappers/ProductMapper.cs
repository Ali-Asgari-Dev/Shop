using Shop.Application.Dto.Requests.Products;
using Shop.Application.Dto.Responses.Products;
using Shop.Domain.Models.Categories;
using Shop.Domain.Models.Products;

namespace Shop.Application.Mappers;

public static class ProductMapper
{
    public static Product Factory(this CreateProductRequestDto dto,Category category) =>
        ProductFactory.New(dto.CategoryId,dto.Title,dto.Description,dto.Price,dto.Inventory,category);

    public static List<AllProductResponseDto> ToAllProductResponseDto(this List<Product> products) =>
        products.Select(p =>
                new AllProductResponseDto(p.Id, p.CategoryId, p.Title, p.Description, p.Price, p.UnitOfDiscountByPrice))
            .ToList();   
}