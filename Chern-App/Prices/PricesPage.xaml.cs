using Chern_App.Prices.Models;
using Chern_App.Prices.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Chern_App.Prices
{
    /// <summary>
    /// Логика взаимодействия для PricesPage.xaml
    /// </summary>
    public partial class PricesPage : Page
    {
        private IViewModel viewModel;
        private List<Product> products;
        public PricesPage()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("uk");
            InitializeComponent();
            viewModel = new ViewVodelSQLite();
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            products = viewModel.getAllProducts();
            if (products != null) productListView.ItemsSource = products;
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (searchProductName.Text.Trim().Length == 0)
            {
                MessageBox.Show(Properties.Resources.ErrorEmptyFieldMessage, Properties.Resources.ErrorMessageHeader, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            products = viewModel.getSearchedProducts(searchProductName.Text);
            if (products != null) productListView.ItemsSource = products;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("C://Program Files (x86)//Google//Chrome//Application//chrome.exe", e.Uri.AbsoluteUri));
            }
            catch
            {
                Process.Start(new ProcessStartInfo("C://Program Files//Google//Chrome//Application//chrome.exe", e.Uri.AbsoluteUri));
            }
            finally
            {
                e.Handled = true;
            }
        }
    }
}
