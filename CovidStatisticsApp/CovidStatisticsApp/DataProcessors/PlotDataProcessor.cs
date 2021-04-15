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
            List<int> cutList = this.WeekList.Select(element => element.DeathCases).ToList();
            return cutList;
        }

        public List<int> ReturnDeaths30Days()
        {
            List<int> cutList = this.MonthList.Select(element => element.DeathCases).ToList();
            return cutList;
        }
        
        public List<int> ReturnDeaths180Days()
        {
            List<int> cutList = this.HalfYearList.Select(element => element.DeathCases).ToList();
            return cutList;
        }
        
        public List<int> ReturnDeathsOverall()
        {
            List<int> cutList = this.OverallList.Select(element => element.DeathCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecovered14Days()
        {
            List<int> cutList = this.WeekList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecovered30Days()
        {
            List<int> cutList = this.MonthList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecovered180Days()
        {
            List<int> cutList = this.HalfYearList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecoveredOverall()
        {
            List<int> cutList = this.OverallList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnActive14Days()
        {
            List<int> cutList = this.WeekList.Select(element => element.ActiveCases).ToList();
            return cutList;
        }

        public List<int> ReturnActive30Days()
        {
            List<int> cutList = this.MonthList.Select(element => element.ActiveCases).ToList();
            return cutList;
        }

        public List<int> ReturnActive180Days()
        {
            List<int> cutList = this.HalfYearList.Select(element => element.ActiveCases).ToList();
            return cutList;
        }

        public List<int> ReturnActiveOverall()
        {
            List<int> cutList = this.OverallList.Select(element => element.ActiveCases).ToList();
            return cutList;
        }
        public List<int> ReturnConfirmed14Days()
        {
            List<int> cutList = this.WeekList.Select(element => element.ConfirmedCases).ToList();
            return cutList;
        }

        public List<int> ReturnConfirmed30Days()
        {
            List<int> cutList = this.MonthList.Select(element => element.ConfirmedCases).ToList();
            return cutList;
        }

        public List<int> ReturnConfirmed180Days()
        {
            List<int> cutList = this.HalfYearList.Select(element => element.ConfirmedCases).ToList();
            return cutList;
        }

        public List<int> ReturnConfirmedOverall()
        {
            List<int> cutList = this.OverallList.Select(element => element.ConfirmedCases).ToList();
            return cutList;
        }
    }
}
