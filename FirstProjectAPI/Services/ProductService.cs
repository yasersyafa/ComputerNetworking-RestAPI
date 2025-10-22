using FirstProjectAPI.DTOs;
using FirstProjectAPI.Repositories;

namespace FirstProjectAPI.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<ProductResponse?> GetProductByIdAsync(Guid id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<ProductResponse> CreateProductAsync(ProductRequest request)
    {
        return await _productRepository.CreateAsync(request);
    }

    public async Task<ProductResponse?> UpdateProductAsync(Guid id, ProductRequest request)
    {
        return await _productRepository.UpdateAsync(id, request);
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        return await _productRepository.DeleteAsync(id);
    }
}

