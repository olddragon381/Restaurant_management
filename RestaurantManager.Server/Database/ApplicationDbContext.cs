using Microsoft.EntityFrameworkCore;
using RestaurantManager.Server.Models;

namespace RestaurantManager.Server.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Dishes> Dishes { get; set; } // Bảng Dishes

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đảm bảo CreatedAt mặc định
            modelBuilder.Entity<Dishes>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
