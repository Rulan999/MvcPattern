using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CA.Application.Dtos;
using CA.Domain;

namespace CA.WebApp.ViewModels
{
    public class WeatherViewModel
    {
        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public List<dynamic> Countries { get; set; }
        public List<dynamic> Cities { get; set; }

        public WeatherDto Output { get; set; }
    }
}
