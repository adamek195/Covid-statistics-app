using CovidStatisticsApp.Client;
using CovidStatisticsApp.DataProcessors;
using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories;
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
        private readonly CountriesRepository countriesRepository;

        public MainWindow()
        {
            countriesRepository = new CountriesRepository();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ApiHelper.InitializeClient();
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridCountries.ItemsSource = countriesRepository.GetCountries();
        }

        private async void LoadCovidData(string country)
        {
            var statisticsList = await CovidDataProcessor.LoadCountryOverallStats(country);
            var yesterdayStats = statisticsList[statisticsList.Count - 1];
            TextBlockConfirmedCases.Text = yesterdayStats.ConfirmedCases.ToString();
            TextBlockDeathCases.Text = yesterdayStats.DeathCases.ToString();
            TextBlockRecoveredCases.Text = yesterdayStats.RecoveredCases.ToString();
            TextBlockActiveCases.Text = yesterdayStats.ActiveCases.ToString();
            TextBlockCountry.Text = yesterdayStats.Country.ToString();
            TextBlockDate.Text = yesterdayStats.Date.ToString();
        }

        private void ButtonSearchData_Click(object sender, RoutedEventArgs e)
        {
            string countryName = TextBoxEnterCountry.Text;

            if (countriesRepository.FindCountryByName(countryName))
            {
                try
                {
                    LoadCovidData(countryName);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
            else
            {
                MessageBox.Show("There is no such country in the database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGridCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Country country = (Country)DataGridCountries.CurrentCell.Item;
            TextBoxEnterCountry.Text = country.Name;
        }
    }
}
