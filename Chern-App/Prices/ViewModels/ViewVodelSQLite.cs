using Chern_App.Prices.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows;

namespace Chern_App.Prices.ViewModels
{
    public class ViewVodelSQLite : IViewModel
    {
        private readonly string cs = @"URI=file:Prices\db_product.db";
        private SQLiteConnection sqlite;

        public ViewVodelSQLite()
        {
            sqlite = new SQLiteConnection(cs);
        }

        public List<Product> getAllProducts()
        {
            string query = "SELECT product.Name, product.Price, product.Link, shop.Name, shop.Link FROM product INNER JOIN shop on shop.Id = product.Shop_id;";
            return executeSelectQuery(query);
        }

        public List<Product> getSearchedProducts(string searchedProductText)
        {
            string searchedProductText2 = searchedProductText[0].ToString().ToUpper() + searchedProductText.Substring(1, searchedProductText.Length - 1);
            string query = "SELECT product.Name, product.Price, product.Link, shop.Name, shop.Link FROM product INNER JOIN shop on shop.Id = product.Shop_id WHERE product.Name LIKE '%" + searchedProductText + "%' OR product.Name LIKE '%" + searchedProductText2 + "%';";
            return executeSelectQuery(query);
        }

        private List<Product> executeSelectQuery(string query)
        {
            try
            {
                sqlite.Open();

                using var cmd = new SQLiteCommand(query, sqlite);
                using SQLiteDataReader rdr = cmd.ExecuteReader();
                List<Product> items = new List<Product>();
                while (rdr.Read())
                {
                    items.Add(new Product() { Name = rdr.GetString(0), Price = rdr.GetString(1), Link = rdr.GetString(2), ShopName = rdr.GetString(3), ShopLink = rdr.GetString(4) });
                }
                if (items.Count == 0)
                {
                    MessageBox.Show(Properties.Resources.InformationNoProductsFoundMessage, Properties.Resources.InformationMessageHeader, MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
                return items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.ErrorMessageHeader, MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            finally
            {
                sqlite.Close();
            }
        }
    }
}
