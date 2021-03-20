using Chern_App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherModule.Models;

namespace WeatherModule.Views
{
    /// <summary>
    /// Логика взаимодействия для WeatherPage.xaml
    /// </summary>
    public partial class WeatherPage : Page
    {
        private WeatherViewModel WeatherViewModel { get; set; }

        public WeatherPage(WeatherViewModel weatherViewModel)
        {
            WeatherViewModel = weatherViewModel;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = WeatherViewModel.GetWeather();
        }
    }
}
