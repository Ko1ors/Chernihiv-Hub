using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chern_App.Prices.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string price;
        private string link;
        private string shopName;
        private string shopLink;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string Link
        {
            get { return link; }
            set
            {
                link = value;
                OnPropertyChanged("Link");
            }
        }

        public string ShopName
        {
            get { return shopName; }
            set
            {
                shopName = value;
                OnPropertyChanged("ShopName");
            }
        }

        public string ShopLink
        {
            get { return shopLink; }
            set
            {
                shopLink = value;
                OnPropertyChanged("ShopLink");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
