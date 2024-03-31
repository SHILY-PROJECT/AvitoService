using Microsoft.EntityFrameworkCore;

namespace AvitoService.Infrastructure.EFCore;

public class AvitoDbContext : DbContext
{
    public AvitoDbContext(DbContextOptions<AvitoDbContext> options) : base(options)
    {
        
    }
}