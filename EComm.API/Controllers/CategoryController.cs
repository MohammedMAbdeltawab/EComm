using EComm.Application.Common.Pagination;
using EComm.Application.Features.Categories.Commands.Create;
using EComm.Application.Features.Categories.Commands.Delete;
using EComm.Application.Features.Categories.Commands.Update;
using EComm.Application.Features.Categories.Dtos;
using EComm.Application.Features.Categories.Queries.GetAllCategories;
using EComm.Application.Features.Categories.Queries.GetCategoryById;
using EComm.Application.Features.Products.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EComm.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
    {
        var command = new UpdateCategoryCommand { Id = id, UpdateCategoryDto = dto };
        var result = await mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteCategoryCommand { Id = id });
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetById(int id)
    {
        var result = await mediator.Send(new GetCategoryByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<CategoryDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await mediator.Send(new GetAllCategoriesQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(result);
    }
}
