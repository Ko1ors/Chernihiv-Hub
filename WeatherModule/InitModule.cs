using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows.Controls;
using WeatherModule.Views;

namespace WeatherModule
{
    public class InitModule : IModule
    {
        private WeatherPage weatherPage = new WeatherPage();

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var btn = new Button();
            btn.Click += Btn_Click;
            btn.Content = "Weather test";
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
