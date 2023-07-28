using ApiReceitas.ApiReceitas.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiReceitas.ApiReceitas.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingrediente> Ingredientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingrediente>()
            .HasKey(i => i.Id);
        }
    }
}
