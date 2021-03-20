using System;
using System.Collections.Generic;
using System.Text;

namespace Chern_App
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }

        public WindInfo Wind { get; set; }

        public Clouds Clouds { get; set; }

        public string Name { get; set; }

        public string Visibility { get; set; }

    }
}
