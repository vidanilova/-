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
            var code = items.code;
            var temp = items.temp;
            var text = items.text;

            return items;
        }
    }
}
