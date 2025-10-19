using EComm.Application.Features.Products.Commands.Create;
using EComm.Application.Features.Products.Commands.Delete;
using EComm.Application.Features.Products.Commands.Update;
using EComm.Application.Features.Products.Dtos;
using EComm.Application.Features.Products.Queries.GetAllProducts;
using EComm.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComm.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
    {
        var command = new UpdateProductCommand { Id = id, UpdateProductDto = dto };
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteProductCommand(id));
        if (!result) return NotFound($"Product with ID '{id}' not found or already deleted.");
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
}