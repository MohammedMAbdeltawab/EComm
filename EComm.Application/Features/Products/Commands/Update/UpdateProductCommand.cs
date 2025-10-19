using EComm.Application.Features.Products.Dtos;
using MediatR;

namespace EComm.Application.Features.Products.Commands.Update;
public class UpdateProductCommand:IRequest<ProductDto>
{
    public int Id { get; set; }
    public UpdateProductDto UpdateProductDto { get; set; }
}

public class  UpdateProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public int? CategoryId { get; set; }
}
