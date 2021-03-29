using CovidStatisticsApp.Client;
using CovidStatisticsApp.DataProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CovidStatisticsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ApiHelper.InitializeClient();
            LoadCovidData("Poland");
        }

        private async void LoadCovidData(string country)
        {
            var statisticsList = await CovidDataProcessor.LoadCountryOverallStats(country);
            var yesterdayStats = statisticsList[statisticsList.Count - 1];
            ConfirmedCasesTextBlock.Text = yesterdayStats.ConfirmedCases.ToString();
            DeathCasesTextBlock.Text = yesterdayStats.DeathCases.ToString();
            RecoveredCasesTextBlock.Text = yesterdayStats.RecoveredCases.ToString();
            ActiveCasesTextBlock.Text = yesterdayStats.ActiveCases.ToString();
            CountryTextBlock.Text = yesterdayStats.Country.ToString();
            DateTextBlock.Text = yesterdayStats.Date.ToString();
        }
    }
}
