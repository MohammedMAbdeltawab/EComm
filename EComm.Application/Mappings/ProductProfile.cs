using AutoMapper;
using EComm.Application.Features.Products.Commands.Create;
using EComm.Application.Features.Products.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Aggregates.ProductAggregate;

namespace EComm.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>()
              .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
              .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false))
              ;

        CreateMap<Product, ProductDto>();
    }
}