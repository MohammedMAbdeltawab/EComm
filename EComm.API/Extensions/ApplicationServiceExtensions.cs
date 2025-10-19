using AutoMapper;
using EComm.Application.Features.Categories.Commands.Create;
using EComm.Application.Features.Products.Commands.Create;
using EComm.Application.Mappings;
using FluentValidation;

namespace EComm.API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
        services.AddMediatR(cfg =>
           cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));

        // AutoMapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(typeof(CategoryProfile));
            cfg.AddProfile(typeof(ProductProfile));
        });
        services.AddSingleton(mapperConfig.CreateMapper());

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining(typeof(Program));

        return services;
    }
}
