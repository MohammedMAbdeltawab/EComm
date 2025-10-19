using AutoMapper;
using EComm.Application.Features.Categories.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Categories.Commands.Create;
public class CreateCategoryHandler(
    IGenericRepository<Category> repo,
    IMapper mapper
    ) : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existing = await repo.GetAllAsync();
        if (existing.Any(c => c.Name.ToLower() == request.Name.ToLower()))
        {
            throw new InvalidOperationException($"Category '{request.Name}' already exists.");
        }

        var category = mapper.Map<Category>(request);
        await repo.AddAsync(category);
        await repo.SaveChangesAsync();
        return mapper.Map<CategoryDto>(category);
    }
}
