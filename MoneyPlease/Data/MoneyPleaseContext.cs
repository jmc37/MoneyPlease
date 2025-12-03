using Microsoft.EntityFrameworkCore;
using MoneyPlease.Models;

namespace MoneyPlease.Data;
public class MoneyPleaseContext : DbContext
{
    public MoneyPleaseContext(DbContextOptions<MoneyPleaseContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ============================
        // USER TABLE
        // ============================
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            entity.Property(e => e.Name)
                .HasColumnName("user_name")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("char(60)")
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.LastUpdatedAt)
                .HasColumnName("last_updated")
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(25).IsRequired(false);

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(64)
                .IsRequired();
        });

        // ============================
        // ACCOUNT TABLE
        // ============================
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.LastUpdatedAt)
                .HasColumnName("last_updated")
                .HasDefaultValueSql("GETDATE()");

            // ONE USER → MANY ACCOUNTS
            entity.HasOne(a => a.User)
                  .WithMany(u => u.Accounts)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ============================
        // TRANSACTIONS TABLE
        // ============================
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transactions");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("transaction_id")
                .UseIdentityColumn();

            entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            entity.Property(e => e.Cost)
                .HasColumnName("cost")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.Property(e => e.AccountId)
                .HasColumnName("account_id")
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("GETDATE()");

            // ONE ACCOUNT → MANY TRANSACTIONS
            entity.HasOne(t => t.Account)
                  .WithMany(a => a.Transactions)
                  .HasForeignKey(t => t.AccountId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
