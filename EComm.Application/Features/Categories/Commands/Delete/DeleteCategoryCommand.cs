using MediatR;

namespace EComm.Application.Features.Categories.Commands.Delete;
public class DeleteCategoryCommand:IRequest<bool>
{
    public int Id { get; set; }
}
