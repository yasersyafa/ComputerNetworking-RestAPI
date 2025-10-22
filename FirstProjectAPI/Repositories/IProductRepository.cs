using FirstProjectAPI.DTOs;

namespace FirstProjectAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductResponse>> GetAllAsync();
    Task<ProductResponse?> GetByIdAsync(Guid id);
    Task<ProductResponse> CreateAsync(ProductRequest request);
    Task<ProductResponse?> UpdateAsync(Guid id, ProductRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}

