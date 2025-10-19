using AutoMapper;
using EComm.API.Exceptions;
using EComm.Application.Features.Categories.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Categories.Queries.GetCategoryById;
public class GetCategoryByIdHandler(
    IGenericRepository<Category> repo,
    IMapper mapper
    ) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await repo.GetByIdAsync(request.Id);
        if (category is null || category.IsDeleted is true)
        {
            throw new NotFoundException($"Category with ID '{request.Id}'not found.");

        }
        return mapper.Map<CategoryDto>(category);
    }
}
