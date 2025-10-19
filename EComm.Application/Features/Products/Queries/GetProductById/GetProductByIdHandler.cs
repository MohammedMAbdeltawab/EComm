using AutoMapper;
using EComm.API.Exceptions;
using EComm.Application.Features.Products.Dtos;
using EComm.Domain.Aggregates.ProductAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Products.Queries.GetProductById;
public class GetProductByIdHandler(
    IGenericRepository<Product> repo,
    IMapper mapper
) : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id);
        if (product is null || product.IsDeleted)
        {
            throw new NotFoundException($"Product with ID '{request.Id}' not found.");
        }

        return mapper.Map<ProductDto>(product);
    }
}
