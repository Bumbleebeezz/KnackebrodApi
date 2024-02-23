using KnackebrodApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnackebrodApi.DataAccess;

public class KnackeBrodDbContext : DbContext
{
    public DbSet<Student> students { get; set; }
    public DbSet<Teacher> teachers { get; set; }

    public KnackeBrodDbContext(DbContextOptions options) : base(options)
    {
    }
}