using EComm.Application.Features.Categories.Dtos;
using MediatR;

namespace EComm.Application.Features.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; set; }
}
