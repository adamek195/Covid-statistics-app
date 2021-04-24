using CovidStatisticsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    public class DailyCasesProcessor
    {
        private readonly List<CovidStatisticsDataViewModel> DataList;

        public DailyCasesProcessor(List<CovidStatisticsDataViewModel> dataList)
        {
            this.DataList = dataList;
        }

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
            for (int i = 0; i < this.DataList.Count - 1; i++)
            {
                DailyCasesList.Add(this.DataList[i] - this.DataList[i + 1]);
            }
            return DailyCasesList;
        }

    }
}
