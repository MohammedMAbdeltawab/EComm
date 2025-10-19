using AutoMapper;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Categories.Commands.Delete;
public class DeleteCategoryHandler
    (
    IGenericRepository<Category> repo,
    IMapper mapper
    ) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repo.GetByIdAsync(request.Id);
        if (category is null) return false;

        category.IsDeleted = true;

        await repo.UpdateAsync(category);
        await repo.SaveChangesAsync();

        return true;
    }

}
