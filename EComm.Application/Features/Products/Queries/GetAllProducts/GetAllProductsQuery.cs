using EComm.Application.Common.Pagination;
using EComm.Application.Features.Products.Dtos;
using MediatR;

namespace EComm.Application.Features.Products.Queries.GetAllProducts;
public class GetAllProductsQuery : IRequest<PagedResult<ProductDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Name { get; set; }
    public string? CategoryName { get; set; }
}
