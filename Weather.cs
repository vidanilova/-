using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherApp
{
    class Weather
    {
        public dynamic GetWeather(string querry)
        {
            string results = "";
            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString(querry);
            }
            dynamic jo = JObject.Parse(results);
            var items = jo.query.results.channel.item.condition;

            return items;
        }

        public dynamic GetWeatherWind(string querry)
        {
            string results = "";
            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString(querry);
            }
            dynamic jo = JObject.Parse(results);
            var items = jo.query.results.channel.wind;

            return items;
        }

        public dynamic GetWeatherAtmosphere(string querry)
        {
            string results = "";
            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString(querry);
            }
            dynamic jo = JObject.Parse(results);
            var items = jo.query.results.channel.atmosphere;

            return items;
        }

        public dynamic GetAstrononyTime(string querry)
        {
            string results = "";
            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString(querry);
            }
            dynamic jo = JObject.Parse(results);
            var items = jo.query.results.channel.astronomy;

            return items;
        }

        public dynamic GetForecast(string querry)
        {
            string results = "";
            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString(querry);
            }
            dynamic jo = JObject.Parse(results);
            var items = jo.query.results.channel.item;
            JArray array = (JArray)items["forecast"];

            return array;
        }
    }
}
