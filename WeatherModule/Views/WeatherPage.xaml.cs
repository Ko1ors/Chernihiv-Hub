using Chern_App;
using System.Windows;
using System.Windows.Controls;

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
            listView.Items.Clear();
            var weatherList = WeatherViewModel.GetWeekWeather();
            if (weatherList != null)
            {
                currentWeather.Visibility = Visibility.Visible;
                foreach (var weather in weatherList)
                {
                    listView.Items.Add(new WeatherDayUC(weather));
                }
            }
        }
    }
}
