using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories.Interfaces;
using CovidStatisticsApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CovidStatisticsApp.Repositories
{
    /// <summary>
    /// Class defining methods related to communication with the database for the Countries table
    /// </summary>
    public class CountriesRepository : Repository, ICountriesRepository
    {
        /// <summary>
        /// implementation method for taking all names available in the country database
        /// </summary>
        /// <returns></returns>
        public List<string> GetCountryNames()
        {
            List<string> countryNames = new List<string>();

            foreach(var country in DbContext.Countries)
            {
                countryNames.Add(country.Name);
            }

            return countryNames;
        }

        /// <summary>
        /// implementation method for taking all countries available in the database
        /// </summary>
        /// <returns></returns>
        public List<CountryViewModel> GetCountries()
        {
            List<Country> countries = DbContext.Countries.ToList();
            return Mapper.Map<List<Country>, List<CountryViewModel>>(countries);
        }

        /// <summary>
        /// implementation of method for finding country by name in the country database
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public bool FindCountryByName(string countryName)
        {
            Country country = DbContext.Countries.SingleOrDefault(c => c.Name == countryName);
            return country != null;
        }
    }
}
