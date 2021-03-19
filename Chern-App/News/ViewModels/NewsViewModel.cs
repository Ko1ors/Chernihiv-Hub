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

        public bool GetFeed()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("user-agent", "MyRSSReader/1.0");
                using (XmlReader reader = XmlReader.Create(webClient.OpenRead(rssChannelUrl)))
                {
                
                        var serializer = new XmlSerializer(typeof(Models.rss));
                        var rss = new rss();
                        rss = (rss)serializer.Deserialize(reader);
                        /*var rssChannel = new RSSChannel();
                        rssChannel.title = feed.Title.Text;
                        rssChannel.description = feed.Description.Text;
                        rssChannel.News = new List<Models.News>();
                        foreach(var item2 in feed.Items)
                        {
                            rssChannel.News.Add(new Models.News() { title = item2.Title.Text});
                        }*/


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
