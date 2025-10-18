using MediatR;
using AutoMapper;
using EComm.Application.DTOs;
using EComm.Application.Queries;
using EComm.Domain.Interfaces;
using EComm.Domain.Entities;

namespace EComm.Application.QueryHandlers
{
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, List<WeatherForecastDto>>
    {
        private readonly IGenericRepository<WeatherForecast> _repository;
        private readonly IMapper _mapper;

        public GetWeatherForecastHandler(IGenericRepository<WeatherForecast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WeatherForecastDto>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await _repository.GetAllAsync();
            return _mapper.Map<List<WeatherForecastDto>>(forecasts.ToList());
        }
    }
}
