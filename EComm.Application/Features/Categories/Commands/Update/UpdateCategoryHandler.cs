using AutoMapper;
using EComm.API.Exceptions;
using EComm.Application.Features.Categories.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Categories.Commands.Update;

public class UpdateCategoryHandler(
    IGenericRepository<Category> repo,
    IMapper mapper
) : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repo.GetByIdAsync(request.Id);
        if (category is null || category.IsDeleted)
        {
            throw new NotFoundException($"Category with ID '{request.Id}' not found.");
        }

        var dto = request.UpdateCategoryDto;

        if (!string.IsNullOrWhiteSpace(dto.Name))
            category.Name = dto.Name;

        if (!string.IsNullOrWhiteSpace(dto.Description))
            category.Description = dto.Description;

        await repo.UpdateAsync(category);
        await repo.SaveChangesAsync();

        return mapper.Map<CategoryDto>(category);
    }
}