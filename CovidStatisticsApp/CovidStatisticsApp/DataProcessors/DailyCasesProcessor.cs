using CovidStatisticsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    /// <summary>
    /// Used to return list of daily cases from given list
    /// Daily data is calculated here, because API does not offer such data
    /// </summary>
    public class DailyCasesProcessor
    {
        private readonly List<CovidStatisticsDataViewModel> DataList;
        
        /// <summary>
        /// Constructor for class
        /// </summary>
        /// <param name="dataList">List of cases to be recalculated properly</param>
        public DailyCasesProcessor(List<CovidStatisticsDataViewModel> dataList)
        {
            this.DataList = dataList;
        }

        /// <summary>
        /// Calculates daily cases
        /// </summary>
        /// <returns>List of daily cases</returns>
        public List<CovidStatisticsDataViewModel> CalculateDailyCases()
        {
            var DailyCasesList = new List<CovidStatisticsDataViewModel>
            {
                new CovidStatisticsDataViewModel
                {
                    DeathCases = 0,
                    ActiveCases = 0,
                    ConfirmedCases = 0,
                    RecoveredCases = 0
                }
            };
            for (int i = 1; i < this.DataList.Count - 1; i++)
            {
                DailyCasesList.Add(this.DataList[i] - this.DataList[i - 1]);
            }
            return DailyCasesList;
        }

    }
}
