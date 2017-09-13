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
        String Querry;
        Weather info = new Weather();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Querry = "https://query.yahooapis.com/v1/public/yql?q=select item.condition from weather.forecast where woeid = 516922&format=json";
            var forecast = info.GetWeather(Querry);
            label1.Text = forecast.text;
        }
    }
}
