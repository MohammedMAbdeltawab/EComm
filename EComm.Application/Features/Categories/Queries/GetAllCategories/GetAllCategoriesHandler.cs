using AutoMapper;
using EComm.Application.Common.Pagination;
using EComm.Application.Features.Categories.Dtos;
using EComm.Domain.Aggregates.CategoryAggregate;
using EComm.Domain.Interfaces;
using MediatR;

namespace EComm.Application.Features.Categories.Queries.GetAllCategories;
public class GetAllCategoriesHandler(
    IGenericRepository<Category> repo,
    IMapper mapper
) : IRequestHandler<GetAllCategoriesQuery, PagedResult<CategoryDto>>
{
    public async Task<PagedResult<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories= await repo.GetAllAsync();
        var totalCount = categories.Count();

        var items = categories
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Where(c=>c.IsDeleted is false)
            .ToList();
        return new PagedResult<CategoryDto>
        {
            Items = mapper.Map<IEnumerable<CategoryDto>>(items),
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
