using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{
    public class PeriodHelper
    {
        private readonly List<int> TwoWeeksList;
        private readonly List<int> MonthList;
        private readonly List<int> HalfYearList;
        private readonly List<int> OverallList;

        public PeriodHelper(List<int> DataList)
        {
            this.TwoWeeksList = DataList.GetRange(DataList.Count - 14, 14);
            this.MonthList = DataList.GetRange(DataList.Count - 30, 30);
            this.HalfYearList = DataList.GetRange(DataList.Count - 180, 180);
            this.OverallList = DataList;
        }

        public List<int> GetSpecificPeriod(Period period)
        {
            if (period == Period.TwoWeeks)
            {
                return this.TwoWeeksList;
            }
            else
            {
                if (period == Period.Month)
                {
                    return this.MonthList;
                }
                else
                {
                    if (period == Period.HalfYear)
                    {
                        return this.HalfYearList;
                    }
                    else
                    {
                        return this.OverallList;
                    }
                }
            }
        }
    }
}
