using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string results = "";

            using (WebClient wc = new WebClient())
            {
                results = wc.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%3D2344116&format=json");
            }

            dynamic jo = JObject.Parse(results);
            var items = jo.query.results.channel.item.condition;
            var code = items.code;
            var temp = items.temp;
            var text = items.text;
            label1.Text = text;

        }
    }
}
