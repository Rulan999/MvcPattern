using AutoMapper;
using CA.Application.Commands;
using CA.Application.Queries;
using CA.Domain;
using CA.Domain.Helpers;
using CA.WebApp.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanWebApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeatherController(ILogger<WeatherController> logger,
                                  IMapper mapper,
                                  IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var output = new WeatherViewModel();
            output.Countries = await PopulateCountries();
            output.Cities = new List<dynamic>();
            return View(output);
        }

        private async Task<List<dynamic>> PopulateCountries()
        {
            var countries = await _mediator.Send(new GetCountriesQuery());
            var resultList = new List<dynamic>();
            resultList.Add(new { Text = "Select One", Value = "" });
            foreach (var item in countries)
            {
                resultList.Add(new { Text = item.CountryName, Value = item.Id });
            }
            return resultList;
        }

        private async Task<List<dynamic>> PopulateCities(int countryId)
        {
            var results = await _mediator.Send(new GetCitiesByCountryQuery() { CountryId = countryId });
            var resultList = new List<dynamic>();
            resultList.Add(new { Text = "Select One", Value = "" });
            foreach (var item in results)
            {
                resultList.Add(new { Text = item.CityName, Value = item.Id });
            }
            return resultList;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(WeatherViewModel input)
        {
            input.Countries = await PopulateCountries();
            input.Cities = new List<dynamic>();
            if(input.CountryId !=0)
            {
                input.Cities = await PopulateCities(input.CountryId);
            }

            if (ModelState.IsValid)
            {
                var output = await _mediator.Send(new GetWeatherQuery() { CityId = input.CityId});

                input.Output = output;
            }
            return View(input);
        }

    }
}
