using CovidStatisticsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    public enum Period
    {
        TwoWeeks,
        Month,
        HalfYear,
        Overall
    }

    public enum CaseType
    {
        Death,
        Recovered,
        Active,
        Confirmed
    }

    public class PlotDataProcessor
    {
        private readonly List<CovidStatisticsDataViewModel> OverallList;

        public PlotDataProcessor(List<CovidStatisticsDataViewModel> DataList)
        {
            this.OverallList = DataList;
        }

        public List<int> ReturnCasesInGivenPeriodAndType(Period period, CaseType caseType)
        {
            var caseTypeHelper = new CaseTypeHelper(this.OverallList);
            var listWithSpecifiedType = caseTypeHelper.GetSpecificCases(caseType);
            var periodHelper = new PeriodHelper(listWithSpecifiedType);
            return periodHelper.GetSpecificPeriod(period);
        }
    }
}
