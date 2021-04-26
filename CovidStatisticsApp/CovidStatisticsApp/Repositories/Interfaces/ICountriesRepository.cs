using CovidStatisticsApp.ViewModels;
using System.Collections.Generic;

namespace CovidStatisticsApp.Repositories.Interfaces
{
    /// <summary>
    /// An interface that defines methods related to communication
    /// with the database for the table Country
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// abstract method for taking all names available in the country database
        /// </summary>
        /// <returns></returns>
        List<string> GetCountryNames();

        /// <summary>
        /// abstract method for taking all countries available in the database
        /// </summary>
        /// <returns></returns>
        List<CountryViewModel> GetCountries();

        /// <summary>
        /// abstract method for finding country by name in the country database
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        bool FindCountryByName(string countryName);
    }
}
