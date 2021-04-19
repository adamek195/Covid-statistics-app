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
        public static async Task<List<CovidStatisticsDataViewModel>> LoadCountryOverallStats(string country)
        {
            ApiHelper.InitializeClient();
            string url = $"https://api.covid19api.com/total/country/{ country }";

            using (HttpResponseMessage response = await ApiHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<CovidStatisticsDataViewModel> values = 
                        JsonConvert.DeserializeObject<List<CovidStatisticsDataViewModel>>(responseBody);
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
