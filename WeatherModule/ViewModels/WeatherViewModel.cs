using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using WeatherModule.Models;

namespace Chern_App
{
    public class WeatherViewModel
    {
        private readonly string apiPath = "api.env";
        private readonly string weatherUrl = "http://api.openweathermap.org/data/2.5/weather?q=Chernihiv&units=metric&appid=";
        private readonly string weekWeatherUrl = "https://api.openweathermap.org/data/2.5/onecall?lat=51&lon=32&exclude=current,minutely,hourly,alerts&units=metric&appid=";
        private string apiKey;

        public bool GetApiKey()
        {
            if (File.Exists(apiPath))
            {
                apiKey = File.ReadAllText(apiPath);
                if (!string.IsNullOrEmpty(apiKey))
                    return true;
            }
            return false;
        }

        public WeatherModel GetWeather()
        {
            if (string.IsNullOrEmpty(apiKey))
                return null;
            try
            {
                var url = weatherUrl + apiKey;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                return new WeatherModel()
                {
                    Icon = weatherResponse.Weather[0].Icon,
                    Temp = weatherResponse.Main.Temp,
                    Description = weatherResponse.Weather[0]?.Description,
                    FeelsLike = weatherResponse.Main.FeelsLike,
                    Humidity = weatherResponse.Main.Humidity,
                    WindSpeed = weatherResponse.Wind.Speed
                };
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return null;
            }
        }

        public List<WeatherModel> GetWeekWeather()
        {
            if (string.IsNullOrEmpty(apiKey))
                return null;
            try
            {
                var url = weekWeatherUrl + apiKey;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                var weatherWeekResponse = JsonConvert.DeserializeObject<WeatherWeekResponse>(response);
                var list = new List<WeatherModel>();
                foreach(var daily in weatherWeekResponse.Daily)
                {
                    list.Add(new WeatherModel()
                    {
                        Icon = daily.Weather[0]?.Icon,
                        Temp = daily.Temp.Day,
                        NightTemp = daily.Temp.Night,
                        Description = daily.Weather[0]?.Description,
                        DayOfWeek = DateTimeOffset.FromUnixTimeSeconds(daily.Dt).DayOfWeek
                    });
                }
                return list;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return null;
            }
        }
    }
}
