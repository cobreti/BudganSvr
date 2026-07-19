using Microsoft.EntityFrameworkCore;

namespace BudganInfra.DBContext;

public class DataContext(DbContextOptions<DataContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<EFColumnsMapping> EFColumnsMappings => Set<EFColumnsMapping>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EFColumnsMapping>(entity =>
        {
            entity.ToTable("EFColumnsMapping");
            entity.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}