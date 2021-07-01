namespace CA.WebApp.ViewModels
{
    public class CountryAddViewModel
    {
        public CountryViewModel Item { get; set; } = new CountryViewModel();
        public string ErrorMessage { get; set; }
    }
}
