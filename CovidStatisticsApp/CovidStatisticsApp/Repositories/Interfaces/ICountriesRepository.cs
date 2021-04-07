using CovidStatisticsApp.ViewModels;
using System.Collections.Generic;

namespace CovidStatisticsApp.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        List<CountryViewModel> GetCountries();
        bool FindCountryByName(string countryName);
    }
}
