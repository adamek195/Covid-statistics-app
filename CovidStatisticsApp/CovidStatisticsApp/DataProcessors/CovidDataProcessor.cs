using CovidStatisticsApp.Client;
using CovidStatisticsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    class CovidDataProcessor
    {
        public async Task<CovidOverallStatisticsForCountryDataModel> LoadCountryOverallTodayCases(string country)
        {
            string url = $"https://api.covid19api.com/total/country/{ country }";

            using (HttpResponseMessage response = await ApiHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    CovidOverallStatisticsForCountryDataModel model = 
                        await response.Content.ReadAsAsync<CovidOverallStatisticsForCountryDataModel>();
                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
