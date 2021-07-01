using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CA.WebApp.ViewModels;
using AutoMapper;
using CA.Domain.Helpers;
using CA.Domain;
using MediatR;
using CA.Application.Queries;
using CA.Application.Commands;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;

namespace CleanWebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class WeatherApiController : Controller
    {
        private readonly ILogger<WeatherApiController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeatherApiController(ILogger<WeatherApiController> logger,
                                  IMapper mapper,
                                  IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            
        }
        [AllowAnonymous]
        [HttpGet("GetCityListByCountry")]
        public async Task<IActionResult> GetCityListByCountry(int countryId)
        {
            var results = await _mediator.Send(new GetCitiesByCountryQuery() { CountryId = countryId });
            var resultList = new List<dynamic>();
            resultList.Add(new { Text = "Select One", Value = "" });
            foreach (var item in results.OrderBy(x => x.CountryName))
            {
                resultList.Add(new { Value = item.Id.ToString(), Label = item.CityName });
            }

            return Ok(resultList);
        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var results = await _mediator.Send(new GetCountriesQuery());
            return Ok(results);
        }
    }
}
