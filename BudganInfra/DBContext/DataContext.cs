using BudganInfra.DBContext.Tables;
using Microsoft.EntityFrameworkCore;

namespace BudganInfra.DBContext;

public class DataContext(DbContextOptions<DataContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<ColumnsMapping> ColumnsMappings => Set<ColumnsMapping>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<AccountTransaction> AccountTransactions => Set<AccountTransaction>();
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

        modelBuilder.Entity<AccountTransaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("GETUTCDATE()");

            entity.Property(e => e.Amount)
                .HasPrecision(18, 2);
            entity.Property(e => e.Balance)
                .HasPrecision(18, 2);

            entity.Property(e => e.RecordType)
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.HasIndex(e => e.FileId);

            entity.HasIndex(e => new { e.AccountId, e.UniqueKey })
                .IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }
}