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
    /// Логика взаимодействия для WeatherDayUC.xaml
    /// </summary>
    public partial class WeatherDayUC : UserControl
    {
        public WeatherDayUC(WeatherModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
