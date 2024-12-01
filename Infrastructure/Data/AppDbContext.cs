using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Step> Steps { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Step>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Title)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(s => s.IsCompleted);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(u => u.PasswordHash)
                      .IsRequired();
                entity.Property(u => u.TimeZone);
            });
        }
    }
}
