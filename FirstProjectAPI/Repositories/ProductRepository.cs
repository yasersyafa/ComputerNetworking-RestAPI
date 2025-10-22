using FirstProjectAPI.Database;
using FirstProjectAPI.DTOs;
using FirstProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectAPI.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products.Select(MapToResponse);
    }

    public async Task<ProductResponse?> GetByIdAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? null : MapToResponse(product);
    }

    public async Task<ProductResponse> CreateAsync(ProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            ProductName = request.Name,
            Description = request.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        
        return MapToResponse(product);
    }

    public async Task<ProductResponse?> UpdateAsync(Guid id, ProductRequest request)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.ProductName = request.Name;
        existingProduct.Description = request.Description;

        await _context.SaveChangesAsync();
        return MapToResponse(existingProduct);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Products.AnyAsync(p => p.Id == id);
    }

    private static ProductResponse MapToResponse(Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.ProductName,
            Description = product.Description ?? string.Empty
        };
    }
}

