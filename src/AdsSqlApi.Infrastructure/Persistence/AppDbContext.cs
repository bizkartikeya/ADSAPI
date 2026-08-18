using AdsSqlApi.Domain.Entities;
using AdsSqlApi.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AdsSqlApi.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Well> Wells => Set<Well>();

    public DbSet<Pad> Pads => Set<Pad>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WellConfiguration());
        modelBuilder.ApplyConfiguration(new PadConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
