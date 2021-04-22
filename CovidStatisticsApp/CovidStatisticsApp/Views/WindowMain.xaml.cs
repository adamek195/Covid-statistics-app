using CovidStatisticsApp.Client;
using CovidStatisticsApp.DataProcessors;
using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories;
using CovidStatisticsApp.ViewModels;
using OxyPlot;
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

        public PlotModel CovidModel { get; set; }
        public PlotModel plot = new PlotModel { };

        public MainWindow()
        {
            this.CovidModel = plot;
            countriesRepository = new CountriesRepository();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridCountries.ItemsSource = countriesRepository.GetCountries();
            AutoCompleteBoxCountry.FilterMode = AutoCompleteFilterMode.Contains;
            AutoCompleteBoxCountry.ItemsSource = countriesRepository.GetCountryNames();
        }

        private async Task<List<int>> LoadCovidData(string country, Period period, CaseType caseType)
        {
            var statisticsList = await CovidDataProcessor.LoadCountryOverallStats(country);
            PlotDataProcessor plotDataProcessor = new PlotDataProcessor(statisticsList);
            var covidData = plotDataProcessor.ReturnCasesInGivenPeriodAndType(period, caseType);
            return covidData;
        }

        private static string formatter(double d)
        {
            if (d < 1E3)
            {
                return String.Format("{0}", d);
            }
            else if (d >= 1E3 && d < 1E6)
            {
                return String.Format("{0}K", d / 1E3);
            }
            else if (d >= 1E6 && d < 1E9)
            {
                return String.Format("{0}M", d / 1E6);
            }
            else if (d >= 1E9)
            {
                return String.Format("{0}B", d / 1E9);
            }
            else
            {
                return String.Format("{0}", d);
            }
        }

        private async void ButtonSearchData_Click(object sender, RoutedEventArgs e)
        {
            CovidModel.InvalidatePlot(true);
            CovidModel.Series.Clear();
            CovidModel.Axes.Clear();
            string countryName = AutoCompleteBoxCountry.Text;
            Period period = Period.TwoWeeks;
            CaseType caseType = CaseType.Active;
            List<int> covidPeriod = new List<int>();

            if (countriesRepository.FindCountryByName(countryName))
            {
                if(RadioButtonActiveCases.IsChecked == true)
                {
                    caseType = CaseType.Active;
                }

                if (RadioButtonConfirmedCases.IsChecked == true)
                {
                    caseType = CaseType.Confirmed;
                }

                if (RadioButtonDeathCases.IsChecked == true)
                {
                    caseType = CaseType.Death;
                }

                if (RadioButtonRecoveredCases.IsChecked == true)
                {
                    caseType = CaseType.Recovered;
                }

                if(RadioButtonLast2Weeks.IsChecked == true)
                {
                    period = Period.TwoWeeks;
                }

                if (RadioButtonLastMonth.IsChecked == true)
                {
                    period = Period.Month;
                }

                if (RadioButtonLastSixMonths.IsChecked == true)
                {
                    period = Period.HalfYear;
                }

                if (RadioButtonOverall.IsChecked == true)
                {
                    period = Period.Overall;
                }

                try
                {
                    List<int> covidData = await LoadCovidData(countryName, period, caseType);

                    for (int i = 0; i < covidData.Count; i++)
                    {
                        covidPeriod.Add(i);
                    }

                    this.CovidModel = new PlotModel { Title = "Covid Plot" };
                    OxyPlot.Series.LineSeries series = new OxyPlot.Series.LineSeries();

                    for (int i = 0; i < covidPeriod.Count; i++)
                    {
                        series.Points.Add(new DataPoint(covidPeriod[i], covidData[i]));
                    }

                    var y_axis = new OxyPlot.Axes.LinearAxis
                    {
                        Position = OxyPlot.Axes.AxisPosition.Left,
                        FontWeight = 700,
                        LabelFormatter = formatter,
                        MajorGridlineStyle = OxyPlot.LineStyle.Solid,
                        MinorGridlineStyle = OxyPlot.LineStyle.Dot,
                        MajorGridlineColor = OxyColor.FromUInt32(0xFFD3D3D3),
                        Title = "Case Type"
                    };

                    var x_axis = new OxyPlot.Axes.LinearAxis
                    {
                        Position = OxyPlot.Axes.AxisPosition.Bottom,
                        FontWeight = 700,
                        MajorGridlineStyle = OxyPlot.LineStyle.Solid,
                        MinorGridlineStyle = OxyPlot.LineStyle.Dot,
                        MajorGridlineColor = OxyColor.FromUInt32(0xFFD3D3D3),
                        Title = "Period"
                    };

                    plot.Series.Add(series);
                    plot.Axes.Add(y_axis);
                    plot.Axes.Add(x_axis);
                    this.CovidModel = plot;
                    this.DataContext = this;
                    this.CovidModel.InvalidatePlot(true);
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
            CountryViewModel countryViewModel = (CountryViewModel)DataGridCountries.CurrentCell.Item;
            AutoCompleteBoxCountry.Text = countryViewModel.Name;
        }
    }
}
