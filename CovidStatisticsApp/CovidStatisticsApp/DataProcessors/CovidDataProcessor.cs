using CovidStatisticsApp.Client;
using CovidStatisticsApp.ViewModels;
using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    public class CovidDataProcessor
    {
        public static async Task<List<CovidStatisticsDataModel>> LoadCountryOverallStats(string country)
        {
            string url = $"https://api.covid19api.com/total/country/{ country }";

            using (HttpResponseMessage response = await ApiHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<CovidStatisticsDataModel> values = 
                        JsonConvert.DeserializeObject<List<CovidStatisticsDataModel>>(responseBody);
                    return values;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
