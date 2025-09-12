using Learn_Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_Net.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.Property(u => u.Email).IsRequired().HasMaxLength(200);
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.FullName).IsRequired().HasMaxLength(200);
                e.Property(u => u.PasswordHash).IsRequired();
            });
        }

    }
}
