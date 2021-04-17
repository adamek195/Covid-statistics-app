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

        [TestInitialize]
        public void TestInitialize()
        {
            var generator = new Random();
            var randomCasesList = new List<int>();
            for (int i = 0; i < 360; i++)
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
    }
}
