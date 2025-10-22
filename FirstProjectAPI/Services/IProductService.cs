using FirstProjectAPI.DTOs;

namespace FirstProjectAPI.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
    Task<ProductResponse?> GetProductByIdAsync(Guid id);
    Task<ProductResponse> CreateProductAsync(ProductRequest request);
    Task<ProductResponse?> UpdateProductAsync(Guid id, ProductRequest request);
    Task<bool> DeleteProductAsync(Guid id);
}

