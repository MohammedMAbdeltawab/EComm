using EComm.Application.Common.Pagination;
using EComm.Application.Features.Categories.Dtos;
using MediatR;

namespace EComm.Application.Features.Categories.Queries.GetAllCategories;
public class GetAllCategoriesQuery : IRequest<PagedResult<CategoryDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}

