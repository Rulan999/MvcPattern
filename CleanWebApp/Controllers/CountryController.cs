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
using System.Threading.Tasks;

namespace CleanWebApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CountryController(ILogger<CountryController> logger,
                                  IMapper mapper,
                                  IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var countries = await _mediator.Send(new GetCountriesQuery());
            var output = new SearchCountryViewModel();
            output.items = countries;
            return View(output);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CountryAddViewModel();
            model.Item = new CountryViewModel();
            model.Item.Id = 0;
            
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var country = new Country();
                var user = new User();
                country.Create(viewModel.Item.CountryName,
                                         user);
                var result = await _mediator.Send(new AddCountryCommand() { Model = country});
                if (result.Status.Equals(CommandStatus.Success))
                {
                    return RedirectToAction("Index", "Country");
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = new CountryUpdateViewModel();
            model.Item = new CountryViewModel();
            var country = await _mediator.Send(new GetCountryByIdQuery() { Id = id });
            if (country == null)
            {
                return NotFound();
            }
            model.Item = _mapper.Map<CountryViewModel>(country);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CountryUpdateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                var country = new Country();
                country.Update(viewModel.Item.Id, viewModel.Item.CountryName,
                                           user);

                var result = await _mediator.Send(new EditCountryCommand() { Model = country });
                if (result.Status.Equals(CommandStatus.Success))
                {
                    return RedirectToAction("Index", "Country");
                }
                
            }
            return View(viewModel);
        }
    }
}
