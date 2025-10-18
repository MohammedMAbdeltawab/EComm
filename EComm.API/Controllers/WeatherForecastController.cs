using MediatR;
using Microsoft.AspNetCore.Mvc;
using EComm.Application.Queries;

namespace EComm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all weather forecasts
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetForecasts()
        {
            var result = await _mediator.Send(new GetWeatherForecastQuery());
            return Ok(result);
        }
    }
}