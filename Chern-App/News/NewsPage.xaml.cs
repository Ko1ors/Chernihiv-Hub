using Chern_App.News.ViewModels;
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

namespace Chern_App.News
{
    /// <summary>
    /// Логика взаимодействия для NewsPage.xaml
    /// </summary>
    public partial class NewsPage : Page
    {
        private NewsViewModel newsViewModel;
        public NewsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            newsViewModel = new NewsViewModel();
            if (newsViewModel.GetFeed())
            {
                foreach(var item in newsViewModel.rss.channel.item)
                {
                    listView.Items.Add(new NewsUC(item));
                }
            }
        }
    }
}
