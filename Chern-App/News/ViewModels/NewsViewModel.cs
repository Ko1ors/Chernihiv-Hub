using Chern_App.News.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Chern_App.News.ViewModels
{
    public class NewsViewModel
    {
        private readonly string rssChannelUrl = "https://chor.gov.ua/nasha-diyalnist/novini?format=feed/*";

        public rss rss;

        public bool GetFeed()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("user-agent", "MyRSSReader/1.0");
                using (XmlReader reader = XmlReader.Create(webClient.OpenRead(rssChannelUrl)))
                {            
                        var serializer = new XmlSerializer(typeof(Models.rss));
                        rss = new rss();
                        rss = (rss)serializer.Deserialize(reader);
                }
                return true;
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }
    }
}
