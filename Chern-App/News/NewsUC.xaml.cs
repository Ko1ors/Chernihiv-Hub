using Chern_App.News.Models;
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
    /// Логика взаимодействия для NewsUC.xaml
    /// </summary>
    public partial class NewsUC : UserControl
    {

        public rssChannelItem item;
        public NewsUC(rssChannelItem item)
        {
            InitializeComponent();
            this.item = item;
        }
    }
}
