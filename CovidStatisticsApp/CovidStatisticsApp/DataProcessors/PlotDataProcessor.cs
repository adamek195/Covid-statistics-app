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

        public List<int> ReturnCasesInGivenPeriodAndType(Period period, CaseType caseType)
        {
            if (caseType == CaseType.Death)
            {
                if (period == Period.TwoWeeks)
                {
                    return this.WeekList.Select(element => element.DeathCases).ToList();
                }
                if (period == Period.Month)
                {
                    return this.MonthList.Select(element => element.DeathCases).ToList();
                }
                if (period == Period.HalfYear)
                {
                    return this.HalfYearList.Select(element => element.DeathCases).ToList();
                }
                if (period == Period.Overall)
                {
                    return this.OverallList.Select(element => element.DeathCases).ToList();
                }
            }

            if (caseType == CaseType.Recovered)
            {
                if (period == Period.TwoWeeks)
                {
                    return this.WeekList.Select(element => element.RecoveredCases).ToList();
                }
                if (period == Period.Month)
                {
                    return this.MonthList.Select(element => element.RecoveredCases).ToList();
                }
                if (period == Period.HalfYear)
                {
                    return this.HalfYearList.Select(element => element.RecoveredCases).ToList();
                }
                if (period == Period.Overall)
                {
                    return this.OverallList.Select(element => element.RecoveredCases).ToList();
                }
            }

            if (caseType == CaseType.Active)
            {
                if (period == Period.TwoWeeks)
                {
                    return this.WeekList.Select(element => element.ActiveCases).ToList();
                }
                if (period == Period.Month)
                {
                    return this.MonthList.Select(element => element.ActiveCases).ToList();
                }
                if (period == Period.HalfYear)
                {
                    return this.HalfYearList.Select(element => element.ActiveCases).ToList();
                }
                if (period == Period.Overall)
                {
                    return this.OverallList.Select(element => element.ActiveCases).ToList();
                }
            }

            if (caseType == CaseType.Confirmed)
            {
                if (period == Period.TwoWeeks)
                {
                    return this.WeekList.Select(element => element.ConfirmedCases).ToList();
                }
                if (period == Period.Month)
                {
                    return this.MonthList.Select(element => element.ConfirmedCases).ToList();
                }
                if (period == Period.HalfYear)
                {
                    return this.HalfYearList.Select(element => element.ConfirmedCases).ToList();
                }
                if (period == Period.Overall)
                {
                    return this.OverallList.Select(element => element.ConfirmedCases).ToList();
                }
            }
            return this.OverallList.Select(element => element.ConfirmedCases).ToList();
        }
    }
}
