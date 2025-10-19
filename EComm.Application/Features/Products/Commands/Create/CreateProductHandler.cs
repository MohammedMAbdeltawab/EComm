using AutoMapper;
using EComm.API.Exceptions;
using EComm.Application.Features.Products.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Aggregates.ProductAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Products.Commands.Create;
public class CreateProductHandler(
    IGenericRepository<Product> productRepo,
    IGenericRepository<Category> categoryRepo,
    IMapper mapper,
    IMediator mediator
) : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepo.GetByIdAsync(request.CategoryId);
        if (category is null || category.IsDeleted) { 
            throw new NotFoundException($"Category with ID '{request.CategoryId}' not found.");
        }

        var product = mapper.Map<Product>(request);

        product.CategoryName = category.Name;

        await productRepo.AddAsync(product);
        await productRepo.SaveChangesAsync();

        await mediator.Publish(product.CreateEvent(), cancellationToken);

        return mapper.Map<ProductDto>(product);
    }
}
