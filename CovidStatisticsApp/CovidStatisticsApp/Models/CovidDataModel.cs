using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.Models
{
    class CovidOverallStatisticsForCountryDataModel
    {
        public int ConfirmedCases { get; set; }
        public int DeathCases { get; set; }
        public int RecoveredCases { get; set; }
        public int ActiveCases { get; set; }
        public string Country { get; set; }

    }
}
