using Shop.Application.Dto.Requests.Categories;
using Shop.Application.Dto.Responses.Categories;

namespace Shop.Application.Contracts;

public interface ICategoryService
{
    Task Create(CreateCategoryRequestDto dto);
    Task<List<AllCategoryResponseDto>> All();
}