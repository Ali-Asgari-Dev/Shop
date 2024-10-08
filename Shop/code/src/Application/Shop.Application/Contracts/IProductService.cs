using Shop.Application.Dto.Requests.Products;
using Shop.Application.Dto.Responses.Products;

namespace Shop.Application.Contracts;

public interface IProductService
{
    Task CreateProduct(CreateProductRequestDto dto);
    Task<List<AllProductResponseDto>> All();
}