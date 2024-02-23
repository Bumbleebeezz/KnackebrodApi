using Microsoft.EntityFrameworkCore;

namespace KnackebrodApi.DataAccess;

public class KnackeBrodDbContext : DbContext
{
    public DbSet<>

    public KnackeBrodDbContext(DbContextOptions options) : base(options)
    {
    }


}