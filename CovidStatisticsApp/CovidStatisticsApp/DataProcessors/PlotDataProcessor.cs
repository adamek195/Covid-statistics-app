using CovidStatisticsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    public class PlotDataProcessor
    {
        private readonly List<CovidStatisticsDataViewModel> WeekList;
        private readonly List<CovidStatisticsDataViewModel> MonthList;
        private readonly List<CovidStatisticsDataViewModel> HalfYearList;
        private readonly List<CovidStatisticsDataViewModel> OverallList;

        public PlotDataProcessor(List<CovidStatisticsDataViewModel> DataList)
        {
            this.WeekList = DataList.GetRange(DataList.Count - 14, 14);
            this.MonthList = DataList.GetRange(DataList.Count - 30, 30);
            this.HalfYearList = DataList.GetRange(DataList.Count - 180, 180);
            this.OverallList = DataList;
        }

        public List<int> ReturnDeaths14Days()
        {
            return this.WeekList.Select(element => element.DeathCases).ToList();
        }

        public List<int> ReturnDeaths30Days()
        {
            return this.MonthList.Select(element => element.DeathCases).ToList();
        }
        
        public List<int> ReturnDeaths180Days()
        {
            return this.HalfYearList.Select(element => element.DeathCases).ToList();
        }
        
        public List<int> ReturnDeathsOverall()
        {
            return this.OverallList.Select(element => element.DeathCases).ToList();
        }

        public List<int> ReturnRecovered14Days()
        {
            return this.WeekList.Select(element => element.RecoveredCases).ToList();
        }

        public List<int> ReturnRecovered30Days()
        {
            return this.MonthList.Select(element => element.RecoveredCases).ToList();
        }

        public List<int> ReturnRecovered180Days()
        {
            return this.HalfYearList.Select(element => element.RecoveredCases).ToList();
        }

        public List<int> ReturnRecoveredOverall()
        {
            return this.OverallList.Select(element => element.RecoveredCases).ToList();
        }

        public List<int> ReturnActive14Days()
        {
            return this.WeekList.Select(element => element.ActiveCases).ToList();
        }

        public List<int> ReturnActive30Days()
        {
            return this.MonthList.Select(element => element.ActiveCases).ToList();
        }

        public List<int> ReturnActive180Days()
        {
            return this.HalfYearList.Select(element => element.ActiveCases).ToList();
        }

        public List<int> ReturnActiveOverall()
        {
            return this.OverallList.Select(element => element.ActiveCases).ToList();
        }
        public List<int> ReturnConfirmed14Days()
        {
            return this.WeekList.Select(element => element.ConfirmedCases).ToList();
        }

        public List<int> ReturnConfirmed30Days()
        {
            return this.MonthList.Select(element => element.ConfirmedCases).ToList();
        }

        public List<int> ReturnConfirmed180Days()
        {
            return this.HalfYearList.Select(element => element.ConfirmedCases).ToList();
        }

        public List<int> ReturnConfirmedOverall()
        {
            return this.OverallList.Select(element => element.ConfirmedCases).ToList();
        }
    }
}
