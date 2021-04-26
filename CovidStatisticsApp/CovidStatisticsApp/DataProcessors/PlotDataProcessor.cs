using CovidStatisticsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    /// <summary>
    /// Enum used to store Period types
    /// </summary>
    public enum Period
    {
        TwoWeeks,
        Month,
        HalfYear,
        Overall
    }

    /// <summary>
    /// Enum used to store CaseType types
    /// </summary>
    public enum CaseType
    {
        Death,
        Recovered,
        Active,
        Confirmed
    }

    /// <summary>
    /// Class used to return sutiable list form given parameters
    /// It benefits from CaseTypeHelper, PeriodHelper and DailyCasesProcessor
    /// </summary>
    public class PlotDataProcessor
    {
        private List<CovidStatisticsDataViewModel> OverallList;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="DataList">Whole data about specific country</param>
        public PlotDataProcessor(List<CovidStatisticsDataViewModel> DataList)
        {
            this.OverallList = DataList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period">Given period</param>
        /// <param name="caseType">Given case type</param>
        /// <param name="IsDaily">Bool used to inform class if daily cases have to be calculated</param>
        /// <returns>Suitable list ready to be displayed</returns>
        public List<int> ReturnCasesInGivenPeriodAndType(Period period, CaseType caseType, bool IsDaily)
        {
            if(IsDaily)
            {
                var dailyCasesProcessor = new DailyCasesProcessor(this.OverallList);
                this.OverallList = dailyCasesProcessor.CalculateDailyCases();
            }
            var caseTypeHelper = new CaseTypeHelper(this.OverallList);
            var listWithSpecifiedType = caseTypeHelper.GetSpecificCases(caseType);
            var periodHelper = new PeriodHelper(listWithSpecifiedType);
            return periodHelper.GetSpecificPeriod(period);
        }
    }
}
