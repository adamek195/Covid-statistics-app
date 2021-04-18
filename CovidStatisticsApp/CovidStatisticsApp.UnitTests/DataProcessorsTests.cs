using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CovidStatisticsApp.DataProcessors;
using System.Collections.Generic;
using System.Linq;
using CovidStatisticsApp.ViewModels;

namespace CovidStatisticsApp.UnitTests
{
    [TestClass]
    public class PeriodHelperTests
    {
        List<int> randomCasesList;
        int OverallDays;

        [TestInitialize]
        public void TestInitialize()
        {
            var generator = new Random();
            var randomCasesList = new List<int>();
            this.OverallDays = generator.Next(minValue: 200, maxValue: 500);
            for (int i = 0; i < this.OverallDays; i++)
            {
                randomCasesList.Add(generator.Next(minValue: 20, maxValue: 20000));
            }
            this.randomCasesList = randomCasesList;
        }

        [TestMethod]
        public void Test_PeriodHelper_ReturnsTwoWeeksAs14Days()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.TwoWeeks).Count, 14);
        }

        [TestMethod]
        public void Test_PeriodHelper_ReturnsMonthAs30Days()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.Month).Count, 30);
        }

        [TestMethod]
        public void Test_PeriodHelper_ReturnsHalfYearAs180Days()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.HalfYear).Count, 180);
        }

        [TestMethod]
        public void Test_PeriodHelper_ReturnsOverallAsOverallDays()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.Overall).Count, this.OverallDays);
        }
    }


    [TestClass]
    public class CaseTypeHelperTests
    {
        List<CovidStatisticsDataViewModel> testCovidModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testCovidModel = new List<CovidStatisticsDataViewModel>()
            {
                new CovidStatisticsDataViewModel
                {
                    ActiveCases = 1200,
                    ConfirmedCases = 200,
                    DeathCases = 10,
                    RecoveredCases = 200,
                },
                new CovidStatisticsDataViewModel
                {
                    ActiveCases = 2200,
                    ConfirmedCases = 1200,
                    DeathCases = 30,
                    RecoveredCases = 300,
                }
            };

        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsConfirmedStatsListWhenConfirmedCasesEnumValueGiven()
        {
            var caseTypeHelper = new CaseTypeHelper(testCovidModel);
            CollectionAssert.AreEqual(testCovidModel.Select(x => x.ConfirmedCases).ToList(), caseTypeHelper.GetSpecificCases(CaseType.Confirmed));
        }


        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsActiveStatsListWhenActiveCasesEnumValueGiven()
        {
            var caseTypeHelper = new CaseTypeHelper(testCovidModel);
            CollectionAssert.AreEqual(testCovidModel.Select(x => x.ActiveCases).ToList(), caseTypeHelper.GetSpecificCases(CaseType.Active));
        }


        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsRecoveredStatsListWhenRecoveredCasesEnumValueGiven()
        {
            var caseTypeHelper = new CaseTypeHelper(testCovidModel);
            CollectionAssert.AreEqual(testCovidModel.Select(x => x.RecoveredCases).ToList(), caseTypeHelper.GetSpecificCases(CaseType.Recovered));
        }


        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsDeathStatsListWhenDeathCasesEnumValueGiven()
        {
            var caseTypeHelper = new CaseTypeHelper(testCovidModel);
            CollectionAssert.AreEqual(testCovidModel.Select(x => x.DeathCases).ToList(), caseTypeHelper.GetSpecificCases(CaseType.Death));
        }
    }
}
