using Chern_App.Prices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chern_App.Prices.ViewModels
{
    interface IViewModel
    {
        List<Product> getAllProducts();
        List<Product> getSearchedProducts(string searchedProductText);
    }
}
