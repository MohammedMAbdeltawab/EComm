using AutoMapper;
using EComm.Application.Common.Pagination;
using EComm.Application.Features.Products.Dtos;
using EComm.Domain.Aggregates.ProductAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Products.Queries.GetAllProducts;
public class GetAllProductsHandler(
    IGenericRepository<Product> repo,
    IMapper mapper
) : IRequestHandler<GetAllProductsQuery, PagedResult<ProductDto>>
{
    public async Task<PagedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repo.GetAllAsync();

        var filtered = products
            .Where(p => !p.IsDeleted)
            .Where(p => string.IsNullOrWhiteSpace(request.Name) || p.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase))
            .Where(p => string.IsNullOrWhiteSpace(request.CategoryName) || p.CategoryName.Contains(request.CategoryName, StringComparison.OrdinalIgnoreCase));

        var totalCount = filtered.Count();

        var paged = filtered
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResult<ProductDto>
        {
            Items = mapper.Map<IEnumerable<ProductDto>>(paged),
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}