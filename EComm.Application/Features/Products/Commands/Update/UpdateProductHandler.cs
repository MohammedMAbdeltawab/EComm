using AutoMapper;
using EComm.API.Exceptions;
using EComm.Application.Features.Products.Commands.Update;
using EComm.Application.Features.Products.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Aggregates.ProductAggregate;
using EComm.Domain.Interfaces;
using MediatR;

public class UpdateProductHandler(
    IGenericRepository<Product> productRepo,
    IGenericRepository<Category> categoryRepo,
    IMapper mapper
) : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepo.GetByIdAsync(request.Id);
        if (product is null || product.IsDeleted)
        {
            throw new NotFoundException($"Product with ID '{request.Id}' not found.");
        }

        var dto = request.UpdateProductDto;

        if (dto.CategoryId.HasValue)
        {
            var category = await categoryRepo.GetByIdAsync(dto.CategoryId.Value);
            if (category is null || category.IsDeleted)
                throw new NotFoundException($"Category with ID '{dto.CategoryId}' not found.");

            product.CategoryName = category.Name;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name)) product.Name = dto.Name;
        if (!string.IsNullOrWhiteSpace(dto.Description)) product.Description = dto.Description;
        if (dto.Price.HasValue) product.Price = dto.Price.Value;
        if (dto.Quantity.HasValue) product.Quantity = dto.Quantity.Value;
        if (!string.IsNullOrWhiteSpace(dto.ImageUrl)) product.ImageUrl = dto.ImageUrl;

        await productRepo.UpdateAsync(product);
        await productRepo.SaveChangesAsync();

        return mapper.Map<ProductDto>(product);
    }
}