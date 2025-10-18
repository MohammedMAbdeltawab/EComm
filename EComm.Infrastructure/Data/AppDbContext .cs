using EComm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed sample data
        modelBuilder.Entity<WeatherForecast>().HasData(
            new WeatherForecast { Id = 1, Date = DateTime.Now, TemperatureC = 25, Summary = "Sunny" },
            new WeatherForecast { Id = 2, Date = DateTime.Now.AddDays(1), TemperatureC = 18, Summary = "Cloudy" },
            new WeatherForecast { Id = 3, Date = DateTime.Now.AddDays(2), TemperatureC = 12, Summary = "Rainy" }
        );
    }
}