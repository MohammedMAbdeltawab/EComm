using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Aggregates.ProductAggregate;
using EComm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Price).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Seeding data
        var CurrentTime = new DateTime(2025, 10, 18, 23, 49, 21, DateTimeKind.Utc);

        modelBuilder.Entity<Category>().HasData(
       new Category { Id = 1, Name = "Electronics", Description = "Electronic Machines", IsDeleted = false, CreationTime = CurrentTime },
       new Category { Id = 2, Name = "Books", Description = "Mix Books", IsDeleted = false, CreationTime = CurrentTime },
       new Category { Id = 3, Name = "Fashion", Description = "Men and women Clothes", IsDeleted = false, CreationTime = CurrentTime }
       );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Samsung S25 Ultra", Description = "Samsung Flagship", Price = 1000, Quantity = 50, ImageUrl = "Image1.PNG", CategoryName = "Electronics", IsDeleted = false, CreationTime = CurrentTime },
            new Product { Id = 2, Name = "Attack On Titan", Description = "adventure Manga", Price = 20, Quantity = 100, ImageUrl = "Image1.PNG", CategoryName = "Books", IsDeleted = false, CreationTime = CurrentTime },
            new Product { Id = 3, Name = "Messi T-Shirt", Description = "Sprot T-Shirt", Price = 40, Quantity = 10, ImageUrl = "Image1.PNG", CategoryName = "Fashion", IsDeleted = false, CreationTime = CurrentTime }
        );



    }
}