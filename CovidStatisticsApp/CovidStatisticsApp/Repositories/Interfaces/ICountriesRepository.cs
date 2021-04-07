using CovidStatisticsApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        List<Country> GetCountries();
        bool FindCountryByName(string countryName);
    }
}
