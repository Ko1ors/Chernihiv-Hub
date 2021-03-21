using Chern_App.Prices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chern_App.Prices.ViewModels
{
    public interface IViewModel
    {
        public List<Product> getAllProducts();
        public List<Product> getSearchedProducts(string searchedProductText);
    }
}
