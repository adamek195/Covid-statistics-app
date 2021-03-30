using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.ViewModels
{
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
    }
}
