using Chern_App.News.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для NewsUC.xaml
    /// </summary>
    public partial class NewsUC : UserControl
    {
        public NewsModel newsModel { get; set; }

        public NewsUC(rssChannelItem item)
        {
            newsModel = new NewsModel();
            newsModel.Title = item.title;
            newsModel.Description = Regex.Replace(item.description, "<.*?>", String.Empty);
            newsModel.Link = item.link;
            newsModel.Date = item.pubDate.Remove(item.pubDate.LastIndexOf('+'));
            InitializeComponent();
        }
    }
}
