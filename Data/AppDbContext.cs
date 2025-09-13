using Learn_Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_Net.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Write> Writes { get; set; } = null!;
        public DbSet<UserWrite> UserWrites { get; set; } = null!;

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

            modelBuilder.Entity<Write>(e =>
            {
                e.HasKey(w => w.Id);
                e.Property(w => w.Title).IsRequired().HasMaxLength(300);
                e.Property(w => w.Content).IsRequired();
                e.Property(w => w.Image).HasMaxLength(500);
                e.Property(w => w.Point).HasDefaultValue(0);
                e.Property(w => w.IsPublished).HasDefaultValue(true);
                e.Property(w => w.Difficulty);
                e.Property(w => w.Category);
            });

            modelBuilder.Entity<UserWrite>(e =>
            {
                e.HasKey(uw => uw.Id); 
                e.HasOne(uw => uw.User)
                 .WithMany(u => u.UserWrites)
                 .HasForeignKey(uw => uw.UserId);

                e.HasOne(uw => uw.Write)
                 .WithMany(w => w.UserWrites)
                 .HasForeignKey(uw => uw.WriteId);

                e.Property(uw => uw.Score).HasDefaultValue(0);
                e.Property(uw => uw.IsCompleted).HasDefaultValue(false);
            });
        }

    }
}
