using CovidStatisticsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.DataProcessors
{

    class CaseTypeHelper
    {

        private readonly List<int> DeathCases;
        private readonly List<int> ActiveCases;
        private readonly List<int> RecoveredCases;
        private readonly List<int> ConfirmedCases;

        public CaseTypeHelper(List<CovidStatisticsDataViewModel> DataList)
        {
            this.DeathCases = DataList.Select(element => element.DeathCases).ToList();
            this.ActiveCases = DataList.Select(element => element.ActiveCases).ToList();
            this.RecoveredCases = DataList.Select(element => element.RecoveredCases).ToList();
            this.ConfirmedCases = DataList.Select(element => element.ConfirmedCases).ToList();
        }

        public List<int> GetSpecificCases(CaseType type)
        {
            if(type == CaseType.Active)
            {
                return this.ActiveCases;
            }
            else
            {
                if(type == CaseType.Death)
                {
                    return this.DeathCases;
                }
                else
                {
                    if(type == CaseType.Recovered)
                    {
                        return this.RecoveredCases;
                    }
                    else
                    {
                        return this.ConfirmedCases;
                    }
                }
            }
        }
    }
}
