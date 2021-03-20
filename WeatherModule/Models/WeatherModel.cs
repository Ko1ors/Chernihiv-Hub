using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WeatherModule.Models
{
    public class WeatherModel : INotifyPropertyChanged
    {
        private string icon;
        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if(value != icon)
                {
                    icon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        private double temp;
        public double Temp
        {
            get
            {
                return temp;
            }
            set
            {
                if (value != temp)
                {
                    temp = value;
                    OnPropertyChanged("Temp");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
