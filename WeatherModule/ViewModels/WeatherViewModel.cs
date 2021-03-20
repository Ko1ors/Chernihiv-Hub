using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using WeatherModule.Models;

namespace Chern_App
{
    public class WeatherViewModel
    {
        private readonly string apiPath = "api.env";
        private readonly string weatherUrl = "http://api.openweathermap.org/data/2.5/weather?q=Chernihiv&units=metric&appid=";
        private string apiKey;

        public bool GetApiKey()
        {
            if (File.Exists(apiPath))
            {
                apiKey = File.ReadAllText(apiPath);
                if(!string.IsNullOrEmpty(apiKey))
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
                return new WeatherModel() { Icon = weatherResponse.Weather[0].Icon, Temp = weatherResponse.Main.Temp};
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
                return null;
            }
        }

        static void Main1(string[] args)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Chernihiv&units=metric&appid";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            Console.WriteLine("Temperature in {0}: {1} °C", weatherResponse.Name, weatherResponse.Main.Temp);
        }


    }
}
