using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CovidStatisticsApp.DataProcessors;
using System.Collections.Generic;
using System.Linq;

namespace CovidStatisticsApp.UnitTests
{
    [TestClass]
    public class CaseTypeHelperTests
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
        public void Test_CaseTypeHelper_ReturnsTwoWeeksAs14Days()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.TwoWeeks).Count, 14);
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsMonthAs30Days()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.Month).Count, 30);
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsHalfYearAs180Days()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.HalfYear).Count, 180);
        }

        [TestMethod]
        public void Test_CaseTypeHelper_ReturnsOverallAsOverallDays()
        {
            var periodHelper = new PeriodHelper(this.randomCasesList);
            Assert.AreEqual<int>(periodHelper.GetSpecificPeriod(Period.Overall).Count, this.OverallDays);
        }
    }
}
