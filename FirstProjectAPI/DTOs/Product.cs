using System.ComponentModel.DataAnnotations;

namespace FirstProjectAPI.DTOs;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class ProductRequest
{
    [MaxLength(50, ErrorMessage = "Product name can't be over than 50 characters")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}