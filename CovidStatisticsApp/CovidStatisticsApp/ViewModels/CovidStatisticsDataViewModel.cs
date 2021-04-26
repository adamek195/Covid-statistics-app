using Newtonsoft.Json;
using System;

namespace CovidStatisticsApp.ViewModels
{
    /// <summary>
    /// CovidStatisticsDataViewModel which is taking from Covid API
    /// </summary>
    public class CovidStatisticsDataViewModel
    {
        [JsonProperty("Confirmed")]
        public int ConfirmedCases { get; set; }
        
        [JsonProperty("Deaths")]
        public int DeathCases { get; set; }
        
        [JsonProperty("Recovered")]
        public int RecoveredCases { get; set; }

        [JsonProperty("Active")]
        public int ActiveCases { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Operator '-' overload for CovidStatisticsDataViewModel
        /// </summary>
        /// <param name="modelFirst"></param>
        /// <param name="modelSecond"></param>
        /// <returns></returns>
        public static CovidStatisticsDataViewModel operator -(CovidStatisticsDataViewModel modelFirst, CovidStatisticsDataViewModel modelSecond)
        {
            var resultModel = new CovidStatisticsDataViewModel()
            {
                DeathCases = modelFirst.DeathCases - modelSecond.DeathCases,
                ConfirmedCases = modelFirst.ConfirmedCases - modelSecond.ConfirmedCases,
                RecoveredCases = modelFirst.RecoveredCases - modelSecond.RecoveredCases,
                ActiveCases = modelFirst.ActiveCases - modelSecond.ActiveCases
            };
            return resultModel;
        }
    }


}
