using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherModule.Models
{
    public class Temp
    {
        [JsonProperty("day")]
        public double Day;

        [JsonProperty("min")]
        public double Min;

        [JsonProperty("max")]
        public double Max;

        [JsonProperty("night")]
        public double Night;

        [JsonProperty("eve")]
        public double Eve;

        [JsonProperty("morn")]
        public double Morn;
    }

    public class FeelsLike
    {
        [JsonProperty("day")]
        public double Day;

        [JsonProperty("night")]
        public double Night;

        [JsonProperty("eve")]
        public double Eve;

        [JsonProperty("morn")]
        public double Morn;
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("main")]
        public string Main;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("icon")]
        public string Icon;
    }

    public class Daily
    {
        [JsonProperty("dt")]
        public int Dt;

        [JsonProperty("sunrise")]
        public int Sunrise;

        [JsonProperty("sunset")]
        public int Sunset;

        [JsonProperty("temp")]
        public Temp Temp;

        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike;

        [JsonProperty("pressure")]
        public int Pressure;

        [JsonProperty("humidity")]
        public int Humidity;

        [JsonProperty("dew_point")]
        public double DewPoint;

        [JsonProperty("wind_speed")]
        public double WindSpeed;

        [JsonProperty("wind_deg")]
        public int WindDeg;

        [JsonProperty("weather")]
        public List<Weather> Weather;

        [JsonProperty("clouds")]
        public int Clouds;

        [JsonProperty("pop")]
        public double Pop;

        [JsonProperty("uvi")]
        public double Uvi;

        [JsonProperty("snow")]
        public double? Snow;

        [JsonProperty("rain")]
        public double? Rain;
    }

    public class WeatherWeekResponse
    {
        [JsonProperty("lat")]
        public int Lat;

        [JsonProperty("lon")]
        public int Lon;

        [JsonProperty("timezone")]
        public string Timezone;

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset;

        [JsonProperty("daily")]
        public List<Daily> Daily;
    }
}
