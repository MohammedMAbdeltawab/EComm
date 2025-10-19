using EComm.Application.Features.Categories.Dtos;
using MediatR;

namespace EComm.Application.Features.Categories.Commands.Update;
public class UpdateCategoryCommand : IRequest<CategoryDto>
{
    public int Id { get; set; }
   public UpdateCategoryDto UpdateCategoryDto { get; set; }
}
public class UpdateCategoryDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
