using Shop.Application.Contracts;
using Shop.Application.Dto.Requests.Products;
using Shop.Application.Dto.Responses.Products;
using Shop.Application.Mappers;
using Shop.Domain.Models.Categories;
using Shop.Domain.Models.Products;

namespace Shop.Application.Services;

public class ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    : IProductService
{
    public async Task CreateProduct(CreateProductRequestDto dto)
    {
        var category = await categoryRepository.FindById(dto.CategoryId);
        if (category == null) throw new ApplicationException("دسته بندی یافت نشد");
        var product = dto.Factory(category);
        await productRepository.Add(product);
        await productRepository.Save();
    }

    public async Task<List<AllProductResponseDto>> All()
    {
        var products = await productRepository.All();
        return products.ToAllProductResponseDto();
    }
}