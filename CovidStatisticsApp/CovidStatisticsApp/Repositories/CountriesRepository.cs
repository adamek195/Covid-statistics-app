using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories.Interfaces;
using CovidStatisticsApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CovidStatisticsApp.Repositories
{
    public class CountriesRepository : Repository, ICountriesRepository
    {
        public List<CountryViewModel> GetCountries()
        {
            List<Country> countries = DbContext.Countries.ToList();
            return Mapper.Map<List<Country>, List<CountryViewModel>>(countries);
        }

        public bool FindCountryByName(string countryName)
        {
            Country country = DbContext.Countries.SingleOrDefault(c => c.Name == countryName);
            return country != null;
        }
    }
}
