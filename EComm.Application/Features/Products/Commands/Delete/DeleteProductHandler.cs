using EComm.Domain.Aggregates.ProductAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Products.Commands.Delete;
public class DeleteProductHandler(
    IGenericRepository<Product> repo
) : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id);
        if (product is null || product.IsDeleted) return false;

        product.IsDeleted = true;
        await repo.UpdateAsync(product);
        await repo.SaveChangesAsync();

        return true;
    }
}
