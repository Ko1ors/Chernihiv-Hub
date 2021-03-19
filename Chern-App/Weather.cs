using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Chern_App
{
    class Weather
    {
        public static object ConsoleManager { get; private set; }

        static void Main(string[] args)
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
