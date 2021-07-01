using System.Collections.Generic;
using CA.Domain;

namespace CA.WebApp.ViewModels
{
    public class SearchCountryViewModel
    {
        public IEnumerable<Country> items { get; set; }
    }
}
