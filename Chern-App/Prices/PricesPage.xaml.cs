using Chern_App.Prices.Models;
using Chern_App.Prices.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            productListView.Items.Clear();
            if (products != null)
                foreach (var product in products)
                {
                    productListView.Items.Add(new ProductUC(product));
                }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (searchProductName.Text.Trim().Length == 0)
            {
                MessageBox.Show(Properties.Resources.ErrorEmptyFieldMessage, Properties.Resources.ErrorMessageHeader, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            products = viewModel.getSearchedProducts(searchProductName.Text);
            productListView.Items.Clear();
            if (products != null)
                foreach (var product in products)
                {
                    productListView.Items.Add(new ProductUC(product));
                }
        }
    }
}
