using Shop.Application.Contracts;
using Shop.Application.Dto.Requests.Categories;
using Shop.Application.Dto.Responses.Categories;
using Shop.Application.Mappers;
using Shop.Domain.Models.Categories;

namespace Shop.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository):ICategoryService
{
    public async Task Create(CreateCategoryRequestDto dto)
    {
        var category = dto.Factory();
        await categoryRepository.Add(category);
        await categoryRepository.Save();
    }

    public async Task<List<AllCategoryResponseDto>> All()
    {
        var categories = await categoryRepository.All();
        return categories.ToAllCategoryResponseDto();
    }
}