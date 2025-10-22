using FirstProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectAPI.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}