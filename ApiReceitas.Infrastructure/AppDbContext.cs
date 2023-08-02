using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Ingrediente> Ingredientes { get; set; }

    public AppDbContext() : this(new DbContextOptionsBuilder<AppDbContext>().UseSqlite(AppConfiguration.Configuration.GetConnectionString("DefaultConnection")).Options)
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(AppConfiguration.Configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingrediente>()
        .HasKey(i => i.Id);
    }
}
