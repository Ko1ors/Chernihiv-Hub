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

        private string description;

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private double feelsLike;

        public double FeelsLike
        {
            get
            {
                return feelsLike;
            }
            set
            {
                if (value != feelsLike)
                {
                    feelsLike = value;
                    OnPropertyChanged("FeelsLike");
                }
            }
        }

        private int humidity;

        public int Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                if (value != humidity)
                {
                    humidity = value;
                    OnPropertyChanged("Humidity");
                }
            }
        }

        private double windSpeed;

        public double WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                if (value != windSpeed)
                {
                    windSpeed = value;
                    OnPropertyChanged("WindSpeed");
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
