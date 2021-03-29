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
        public static async Task<CovidStatisticsDataModel> LoadCountryOverallTodayCases(string country)
        {
            string url = $"https://api.covid19api.com/total/country/{ country }";

            using (HttpResponseMessage response = await ApiHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //string responsebody = await response.content.readasstringasync();
                    //dataset dataset = jsonconvert.deserializeobject<dataset>(responsebody);

                    //datatable datatable = dataset.tables["table1"];

                    //console.writeline(datatable.rows.count);
                    //2

                    //foreach (datarow row in datatable.rows)
                    //{
                    //    console.writeline(row["country"] + " - " + row["confirmed"]);
                    //}

                    CovidStatisticsDataModel model = 
                        await response.Content.ReadAsAsync<CovidStatisticsDataModel>();
                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async void PrintLoadedData(string country)
        {
            string url = $"https://api.covid19api.com/total/country/{ country }";

            using (HttpResponseMessage response = await ApiHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                   
                    List<CovidStatisticsDataModel> values = JsonConvert.DeserializeObject<List<CovidStatisticsDataModel>>(responseBody);
                    foreach (var kajetan in values)
                    {
                        Console.WriteLine(kajetan.ActiveCases);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
