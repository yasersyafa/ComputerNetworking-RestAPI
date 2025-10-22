namespace FirstProjectAPI.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
}