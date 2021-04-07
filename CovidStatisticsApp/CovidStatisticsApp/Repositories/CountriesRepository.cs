using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.Repositories
{
    public class CountriesRepository : Repository, ICountriesRepository
    {
        public List<Country> GetCountries()
        {
            List<Country> countries = DbContext.Countries.ToList();
            return countries;
        }

        public bool FindCountryByName(string countryName)
        {
            Country country = DbContext.Countries.SingleOrDefault(c => c.Name == countryName);
            return country != null;
        }
    }
}
