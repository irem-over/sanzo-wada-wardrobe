using Microsoft.EntityFrameworkCore;
using SanzoWada.Api.Models;

namespace SanzoWada.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ClothingItem> ClothingItems {get; set;}
}