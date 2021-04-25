using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CovidStatisticsApp.DataProcessors;
using System.Collections.Generic;
using System.Linq;
using CovidStatisticsApp.ViewModels;
using System.Threading.Tasks;
using CovidStatisticsApp.Client;

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
        CaseTypeHelper caseTypeHelper;

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
            this.caseTypeHelper = new CaseTypeHelper(testCovidModel);
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsConfirmedStatsListWhenConfirmedCasesEnumValueGiven()
        {
            CollectionAssert.AreEqual(this.testCovidModel.Select(x => x.ConfirmedCases).ToList(), this.caseTypeHelper.GetSpecificCases(CaseType.Confirmed));
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsActiveStatsListWhenActiveCasesEnumValueGiven()
        {
            CollectionAssert.AreEqual(this.testCovidModel.Select(x => x.ActiveCases).ToList(), this.caseTypeHelper.GetSpecificCases(CaseType.Active));
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsRecoveredStatsListWhenRecoveredCasesEnumValueGiven()
        {
            CollectionAssert.AreEqual(this.testCovidModel.Select(x => x.RecoveredCases).ToList(), this.caseTypeHelper.GetSpecificCases(CaseType.Recovered));
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsDeathStatsListWhenDeathCasesEnumValueGiven()
        {
            CollectionAssert.AreEqual(this.testCovidModel.Select(x => x.DeathCases).ToList(), this.caseTypeHelper.GetSpecificCases(CaseType.Death));
        }
    }


    [TestClass]
    public class PlotDataProcessorTests
    {
        private List<CovidStatisticsDataViewModel> testCovidModelList;
        private IEnumerable<Period> periodValues;
        private IEnumerable<CaseType> caseTypeValues;

        [TestInitialize]
        public void TestInitialize()
        {
            var generator = new Random();
            var overallDays = generator.Next(minValue: 200, maxValue: 500);
            this.testCovidModelList = new List<CovidStatisticsDataViewModel>();

            for (int i = 0; i < overallDays; i++)
            {
                var covidStatsModel = new CovidStatisticsDataViewModel
                {
                    ActiveCases = generator.Next(minValue: 300, maxValue: 30000),
                    ConfirmedCases = generator.Next(minValue: 300, maxValue: 30000),
                    DeathCases = generator.Next(minValue: 300, maxValue: 30000),
                    RecoveredCases = generator.Next(minValue: 300, maxValue: 30000),
                };
                this.testCovidModelList.Add(covidStatsModel);
            }
            this.periodValues = Enum.GetValues(typeof(Period)).Cast<Period>();
            this.caseTypeValues = Enum.GetValues(typeof(CaseType)).Cast<CaseType>();
        }

        [TestMethod]
        public void Test_PlotDataProcessor_ReturnsCorrectListFromGivenPeriodAndCaseTypeTotal()
        {
            foreach(var caseTypeValue in this.caseTypeValues)
            {
                foreach(var periodValue in this.periodValues)
                {
                    PlotDataProcessor plotDataProcessor = new PlotDataProcessor(this.testCovidModelList);
                    var dataList = plotDataProcessor.ReturnCasesInGivenPeriodAndType(periodValue, caseTypeValue, false);

                    CaseTypeHelper caseTypeHelper = new CaseTypeHelper(this.testCovidModelList);
                    var listWithSpecifiedType = caseTypeHelper.GetSpecificCases(caseTypeValue);
                    PeriodHelper periodHelper = new PeriodHelper(listWithSpecifiedType);
                    var listWithSpecifiedTypeAndPeriod = periodHelper.GetSpecificPeriod(periodValue);

                    CollectionAssert.AreEqual(dataList, listWithSpecifiedTypeAndPeriod);
                }
            }
        }

        [TestMethod]
        public void Test_PlotDataProcessor_ReturnsCorrectListFromGivenPeriodAndCaseTypeDaily()
        {
            foreach (var caseTypeValue in this.caseTypeValues)
            {
                foreach (var periodValue in this.periodValues)
                {
                    PlotDataProcessor plotDataProcessor = new PlotDataProcessor(this.testCovidModelList);
                    var dataList = plotDataProcessor.ReturnCasesInGivenPeriodAndType(periodValue, caseTypeValue, true);

                    DailyCasesProcessor dailyCasesProcessor = new DailyCasesProcessor(this.testCovidModelList);
                    var dailyCasesTestList = dailyCasesProcessor.CalculateDailyCases();
                    CaseTypeHelper caseTypeHelper = new CaseTypeHelper(dailyCasesTestList);
                    var listWithSpecifiedTypeDaily = caseTypeHelper.GetSpecificCases(caseTypeValue);
                    PeriodHelper periodHelper = new PeriodHelper(listWithSpecifiedTypeDaily);
                    var listWithSpecifiedTypeAndPeriodDaily = periodHelper.GetSpecificPeriod(periodValue);

                    CollectionAssert.AreEqual(dataList, listWithSpecifiedTypeAndPeriodDaily);
                }
            }
        }
    }


    [TestClass]
    public class CovidDataProcessorTests 
    {
        List<string> correctCountries;
        List<string> invalidCountries;

        [TestInitialize]
        public void TestInitialize()
        {
            this.correctCountries = new List<string>(new string[] { "Poland", "Germany", "India" , "USA"});
            this.invalidCountries = new List<string>(new string[] { "Apple", "420", "Country" });
        }

        [TestMethod]
        public async Task Test_CovidDataProcessor_RetrieveCorrectDataFromAPIWithCorrectCountryGiven()
        {
            foreach (var correctCountry in this.correctCountries)
            {
                var dataLoaded = await CovidDataProcessor.LoadCountryOverallStats(correctCountry);
                Assert.IsNotNull(dataLoaded);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Test_CovidDataProcessor_RaisesErrorWhenIncorrectCountryNameGiven()
        {
            foreach (var invalidCountry in this.invalidCountries)
            {
                _ = await CovidDataProcessor.LoadCountryOverallStats(invalidCountry);
            }
        }
    }
}
