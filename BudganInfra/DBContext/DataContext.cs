using BudganInfra.DBContext.Tables;
using Microsoft.EntityFrameworkCore;

namespace BudganInfra.DBContext;

public class DataContext(DbContextOptions<DataContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<ColumnsMapping> ColumnsMappings => Set<ColumnsMapping>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColumnsMapping>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("GETUTCDATE()");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("GETUTCDATE()");
        });

        base.OnModelCreating(modelBuilder);
    }
}