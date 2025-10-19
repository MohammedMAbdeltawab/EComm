using AutoMapper;
using EComm.Application.Features.Categories.Commands.Create;
using EComm.Application.Features.Categories.Commands.Update;
using EComm.Application.Features.Categories.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;

namespace EComm.Application.Mappings;
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryCommand, Category>()
            .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false));

        CreateMap<UpdateCategoryCommand, Category>();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
