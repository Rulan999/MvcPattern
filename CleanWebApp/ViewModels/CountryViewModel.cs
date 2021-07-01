using System;
using System.ComponentModel.DataAnnotations;
using CA.Domain.Helpers;
using CA.Infrastructure.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace CA.WebApp.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CountryFieldLength.CountryNameMaxLength, MinimumLength = 2)]
        public string CountryName { get; set; }

    }
}
