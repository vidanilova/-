﻿using System;
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
using System.IO;
using System.Reflection;

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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Querry = "https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid = 516922 and u='c' &format=json";
            var Generalforecast = info.GetWeather(Querry);
            var Windforecast = info.GetWeatherWind(Querry);
            var Atmosphereforecast = info.GetWeatherAtmosphere(Querry);
            var AstronomyTime = info.GetAstrononyTime(Querry);
            var Forecast = info.GetForecast(Querry);
   

            City.Text = "Rymanów";
            Local.Text = "Aktualna Prognoza";
            label1.Text = Generalforecast.text;
            label2.Text = Generalforecast.temp + " C";
            label3.Text = Windforecast.speed + " km/h";
            label4.Text = Atmosphereforecast.humidity + " %";
            label11.Text = AstronomyTime.sunrise;
            label12.Text = AstronomyTime.sunset;

            Day1.Text = Forecast[0].day;
            Day2.Text = Forecast[1].day;
            Day3.Text = Forecast[2].day;
            Day4.Text = Forecast[3].day;
            Day5.Text = Forecast[4].day;
             
            temp1.Text = Forecast[0].high + " C";
            temp2.Text = Forecast[1].high + " C";
            temp3.Text = Forecast[2].high + " C";
            temp4.Text = Forecast[3].high + " C";
            temp5.Text = Forecast[4].high + " C";

            con1.Text = Forecast[0].text;
            con2.Text = Forecast[1].text;
            con3.Text = Forecast[2].text;
            con4.Text = Forecast[3].text;
            con5.Text = Forecast[4].text;

            SetUp();
        }

        static double Celcius(double f)
        {
            double c = 5 / 9 * (f - 32);

            return c;
        }

        public void SetUp()
        {

            //Obrazki
            if (label1.Text == "Wietrznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\breezy.png");
                pictureBox2.Image = Image.FromFile(filePath);
            }
            if (label1.Text == "Słonecznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\sunny.png");
                pictureBox2.Image = Image.FromFile(filePath);
            }

            if (label1.Text == "Rzeźko")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\windy.png");
                pictureBox2.Image = Image.FromFile(filePath);
            }

            //Prognoza
            PolishDays(Day1);
            PolishDays(Day2);
            PolishDays(Day3);
            PolishDays(Day4);
            PolishDays(Day5);

            PolishCondition(label1);
            PolishCondition(con1);
            PolishCondition(con2);
            PolishCondition(con3);
            PolishCondition(con4);
            PolishCondition(con5);
            CorrectPic();
        }

        public void PolishDays(Label day)
        {
            if (day.Text == "Mon")
            {
                day.Text = "Poniedziałek";
            }
            if (day.Text == "Tue")
            {
                day.Text = "Wtorek";
            }
            if (day.Text == "Wed")
            {
                day.Text = "Środa";
            }
            if (day.Text == "Thu")
            {
                day.Text = "Czwartek";
            }
            if (day.Text == "Fri")
            {
                day.Text = "Piątek";
            }
            if (day.Text == "Sat")
            {
                day.Text = "Sobota";
            }
            if (day.Text == "Sun")
            {
                day.Text = "Niedziela";
            }
        }
        public void PolishCondition(Label con)
        {
            if (con.Text == "Breezy")
            {
                con.Text = "Rzeźko";
            }
            if (con.Text == "Cloudy")
            {
                con.Text = "Pochmurno";
            }
            if (con.Text == "Mostly Cloudy")
            {
                con.Text = "Zachmurzenie";
            }
            if (con.Text == "Sunny")
            {
                con.Text = "Słonecznie";
            }
            if (con.Text == "Rain")
            {
                con.Text = "Deszcz";
            }
            if (con.Text == "Showers")
            {
                con.Text = "Opady";
            }
            if (con.Text == "Scattered Showers")
            {
                con.Text = "Przeloty";
            }
            if (con.Text == "Scattered Thunderstorms")
            {
                con.Text = "Lekka Burza";
            }
            if (con.Text == "Thunderstorms")
            {
                con.Text = "Burza";
            }

        }
        public void CorrectPic()
        {
            
        }

    }
}
