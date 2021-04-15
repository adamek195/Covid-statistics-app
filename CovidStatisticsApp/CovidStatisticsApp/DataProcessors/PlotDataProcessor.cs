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
        private List<CovidStatisticsDataViewModel> DataList;
        private readonly int Size;

        public PlotDataProcessor(List<CovidStatisticsDataViewModel> DataList)
        {
            this.DataList = DataList;
            this.Size = DataList.Count;
        }

        public List<int> ReturnDeaths14Days()
        {
            List<CovidStatisticsDataViewModel> subList = this.DataList.GetRange(this.Size - 14, 14);
            List<int> cutList = subList.Select(element => element.DeathCases).ToList();
            return cutList;
        }

        public List<int> ReturnDeaths30Days()
        {
            List<CovidStatisticsDataViewModel> subList = this.DataList.GetRange(this.Size - 30, 30);
            List<int> cutList = subList.Select(element => element.DeathCases).ToList();
            return cutList;
        }
        
        public List<int> ReturnDeaths180Days()
        {
            List<CovidStatisticsDataViewModel> subList = this.DataList.GetRange(this.Size - 180, 180);
            List<int> cutList = subList.Select(element => element.DeathCases).ToList();
            return cutList;
        }
        
        public List<int> ReturnDeathsOverall()
        {
            List<int> cutList = DataList.Select(element => element.DeathCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecovered14Days()
        {
            List<CovidStatisticsDataViewModel> subList = this.DataList.GetRange(this.Size - 14, 14);
            List<int> cutList = subList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecovered30Days()
        {
            List<CovidStatisticsDataViewModel> subList = this.DataList.GetRange(this.Size - 30, 30);
            List<int> cutList = subList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecovered180Days()
        {
            List<CovidStatisticsDataViewModel> subList = this.DataList.GetRange(this.Size - 180, 180);
            List<int> cutList = subList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }

        public List<int> ReturnRecoveredOverall()
        {
            List<int> cutList = DataList.Select(element => element.RecoveredCases).ToList();
            return cutList;
        }
    }
    

    /*
    period: 14days 30d 180d overall
    cases: confirmed deaths recovered active    
     */
}
