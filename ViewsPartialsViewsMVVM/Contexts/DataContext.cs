using Microsoft.EntityFrameworkCore;
using ViewsPartialsViewsMVVM.Models.Entities;

namespace ViewsPartialsViewsMVVM.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }  
    public DbSet<ProductOptionsEntity> ProductOptions { get; set; } 
}
