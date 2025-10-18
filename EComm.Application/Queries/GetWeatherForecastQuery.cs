using EComm.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Application.Queries;
public class GetWeatherForecastQuery : IRequest<List<WeatherForecastDto>>
{
}
