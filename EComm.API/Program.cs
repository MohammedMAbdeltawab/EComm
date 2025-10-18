using EComm.Infrastructure;
using EComm.Application.Mappings;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
    typeof(EComm.Application.Queries.GetWeatherForecastQuery).Assembly
));

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

// Infrastructure
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=EComm.db";
builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Create database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EComm.Infrastructure.Data.AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();