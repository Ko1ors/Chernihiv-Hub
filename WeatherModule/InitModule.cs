using Chern_App;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using WeatherModule.Views;

namespace WeatherModule
{
    public class InitModule : IModule
    {
        private WeatherPage weatherPage = new WeatherPage();
        private SideBarElement weatherElement;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var btn = new Button();
            btn.Click += Btn_Click;
            btn.SetBinding(Button.ContentProperty, new Binding("CurrentName"));

            weatherElement = new SideBarElement();
            weatherElement.FullName = "☁ WEATHER ";
            weatherElement.ShortName = "☁";
            btn.DataContext = weatherElement;

            Chern_App.ModuleManager.AddButtonRequest(btn);
        }

        private void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Chern_App.ModuleManager.ShowPageRequest(weatherPage);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
