using CovidStatisticsApp.ViewModels;
using System.Collections.Generic;

namespace CovidStatisticsApp.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        List<string> GetCountryNames();
        List<CountryViewModel> GetCountries();
        bool FindCountryByName(string countryName);
    }
}
