using EComm.Application.Features.Categories.Dtos;
using MediatR;

namespace EComm.Application.Features.Categories.Commands.Create;
public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
