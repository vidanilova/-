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
            if (label1.Text == "Breezy")
            {
                label1.Text = "Rzeźko";
            }

            if (label1.Text == "Clear")
            {
                label1.Text = "Słonecznie";
            }

            if (label1.Text == "Windy")
            {
                label1.Text = "Wietrznie";
            }

            if (label1.Text == "Showers")
            {
                label1.Text = "Przelotne Opady";
            }

            if (label1.Text == "Rain")
            {
                label1.Text = "Deszcz";
            }

            if (label1.Text == "Mostly Couldy")
            {
                label1.Text = "Zachmurzenie";
            }
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
            PolishDays();
            PolishCondition();
            CorrectPic();
        }

        public void PolishDays()
        {
            //Day1
            if (Day1.Text == "Thu")
            {
                Day1.Text = "Czwartek";
            }
            if (Day1.Text == "Fri")
            {
                Day1.Text = "Piątek";
            }
            if (Day1.Text == "Sat")
            {
                Day1.Text = "Sobota";
            }
            if (Day1.Text == "Sun")
            {
                Day1.Text = "Niedziela";
            }
            if (Day1.Text == "Mon")
            {
                Day1.Text = "Poniedziałek";
            }
            if (Day1.Text == "Tue")
            {
                Day1.Text = "Wtorek";
            }
            if (Day1.Text == "Wed")
            {
                Day1.Text = "Środa";
            }
            //Day2
            if (Day2.Text == "Thu")
            {
                Day2.Text = "Czwartek";
            }
            if (Day2.Text == "Fri")
            {
                Day2.Text = "Piątek";
            }
            if (Day2.Text == "Sat")
            {
                Day2.Text = "Sobota";
            }
            if (Day2.Text == "Sun")
            {
                Day2.Text = "Niedziela";
            }
            if (Day2.Text == "Mon")
            {
                Day2.Text = "Poniedziałek";
            }
            if (Day2.Text == "Tue")
            {
                Day2.Text = "Wtorek";
            }
            if (Day2.Text == "Wed")
            {
                Day2.Text = "Środa";
            }

            //Day3
            if (Day3.Text == "Thu")
            {
                Day3.Text = "Czwartek";
            }
            if (Day3.Text == "Fri")
            {
                Day3.Text = "Piątek";
            }
            if (Day3.Text == "Sat")
            {
                Day3.Text = "Sobota";
            }
            if (Day3.Text == "Sun")
            {
                Day3.Text = "Niedziela";
            }
            if (Day3.Text == "Mon")
            {
                Day3.Text = "Poniedziałek";
            }
            if (Day3.Text == "Tue")
            {
                Day3.Text = "Wtorek";
            }
            if (Day3.Text == "Wed")
            {
                Day3.Text = "Środa";
            }

            //Day4
            if (Day4.Text == "Thu")
            {
                Day4.Text = "Czwartek";
            }
            if (Day4.Text == "Fri")
            {
                Day4.Text = "Piątek";
            }
            if (Day4.Text == "Sat")
            {
                Day4.Text = "Sobota";
            }
            if (Day4.Text == "Sun")
            {
                Day4.Text = "Niedziela";
            }
            if (Day4.Text == "Mon")
            {
                Day4.Text = "Poniedziałek";
            }
            if (Day4.Text == "Tue")
            {
                Day4.Text = "Wtorek";
            }
            if (Day4.Text == "Wed")
            {
                Day4.Text = "Środa";
            }

            //Day5
            if (Day5.Text == "Thu")
            {
                Day5.Text = "Czwartek";
            }
            if (Day5.Text == "Fri")
            {
                Day5.Text = "Piątek";
            }
            if (Day5.Text == "Sat")
            {
                Day5.Text = "Sobota";
            }
            if (Day5.Text == "Sun")
            {
                Day5.Text = "Niedziela";
            }
            if (Day5.Text == "Mon")
            {
                Day5.Text = "Poniedziałek";
            }
            if (Day5.Text == "Tue")
            {
                Day5.Text = "Wtorek";
            }
            if (Day5.Text == "Wed")
            {
                Day5.Text = "Środa";
            }
        }
        public void PolishCondition()
        {
            //MainCon
            if (label1.Text == "Breezy")
            {
                label1.Text = "Rzeźko";
            }

            if (label1.Text == "Sunny")
            {
                label1.Text = "Słonecznie";
            }

            if (label1.Text == "Windy")
            {
                label1.Text = "Wietrznie";
            }

            if (label1.Text == "Showers")
            {
                label1.Text = "Opady";
            }

            if (label1.Text == "Rain")
            {
                label1.Text = "Deszcz";
            }

            if (label1.Text == "Mostly Cloudy")
            {
                label1.Text = "Zachmurzenie";
            }

            if (label1.Text == "Scattered Showers")
            {
                label1.Text = "Przeloty";
            }

            if (label1.Text == "Thunderstorms")
            {
                label1.Text = "Burze";
            }

            if (label1.Text == "Drizzle")
            {
                label1.Text = "Mrzawka";
            }

            if (label1.Text == "Partly Cloudy")
            {
                label1.Text = "Pochmurno";
            }
            //Con1
            if (con1.Text == "Breezy")
            {
                con1.Text = "Rzeźko";
            }

            if (con1.Text == "Sunny")
            {
                con1.Text = "Słonecznie";
            }

            if (con1.Text == "Windy")
            {
                con1.Text = "Wietrznie";
            }

            if (con1.Text == "Showers")
            {
                con1.Text = "Opady";
            }

            if (con1.Text == "Rain")
            {
                con1.Text = "Deszcz";
            }

            if (con1.Text == "Mostly Cloudy")
            {
                con1.Text = "Zachmurzenie";
            }

            if (con1.Text == "Scattered Showers")
            {
                con1.Text = "Przeloty";
            }

            if (con1.Text == "Thunderstorms")
            {
                con1.Text = "Burze";
            }

            if (con1.Text == "Drizzle")
            {
                con1.Text = "Mrzawka";
            }

            if (con1.Text == "Partly Cloudy")
            {
                con1.Text = "Pochmurno";
            }
            //Con2

            if (con2.Text == "Breezy")
            {
                con2.Text = "Rzeźko";
            }

            if (con2.Text == "Sunny")
            {
                con2.Text = "Słonecznie";
            }

            if (con2.Text == "Windy")
            {
                con2.Text = "Wietrznie";
            }

            if (con2.Text == "Showers")
            {
                con2.Text = "Opady";
            }

            if (con2.Text == "Rain")
            {
                con2.Text = "Deszcz";
            }

            if (con2.Text == "Mostly Cloudy")
            {
                con2.Text = "Zachmurzenie";
            }

            if (con2.Text == "Scattered Showers")
            {
                con2.Text = "Przeloty";
            }

            if (con2.Text == "Thunderstorms")
            {
                con2.Text = "Burze";
            }

            if (con2.Text == "Drizzle")
            {
                con2.Text = "Mrzawka";
            }

            if (con2.Text == "Partly Cloudy")
            {
                con2.Text = "Pochmurno";
            }

            //Con3
            if (con3.Text == "Breezy")
            {
                con3.Text = "Rzeźko";
            }

            if (con3.Text == "Sunny")
            {
                con3.Text = "Słonecznie";
            }

            if (con3.Text == "Windy")
            {
                con3.Text = "Wietrznie";
            }

            if (con3.Text == "Showers")
            {
                con3.Text = "Opady";
            }

            if (con3.Text == "Rain")
            {
                con3.Text = "Deszcz";
            }

            if (con3.Text == "Mostly Cloudy")
            {
                con3.Text = "Zachmurzenie";
            }

            if (con3.Text == "Scattered Showers")
            {
                con3.Text = "Przeloty";
            }

            if (con3.Text == "Thunderstorms")
            {
                con3.Text = "Burze";
            }

            if (con3.Text == "Drizzle")
            {
                con3.Text = "Mrzawka";
            }

            if (con3.Text == "Partly Cloudy")
            {
                con3.Text = "Pochmurno";
            }

            //Con4
            if (con4.Text == "Breezy")
            {
                con4.Text = "Rzeźko";
            }

            if (con4.Text == "Sunny")
            {
                con4.Text = "Słonecznie";
            }

            if (con4.Text == "Windy")
            {
                con4.Text = "Wietrznie";
            }

            if (con4.Text == "Showers")
            {
                con4.Text = "Opady";
            }

            if (con4.Text == "Rain")
            {
                con4.Text = "Deszcz";
            }

            if (con4.Text == "Mostly Cloudy")
            {
                con4.Text = "Zachmurzenie";
            }

            if (con4.Text == "Scattered Showers")
            {
                con4.Text = "Przeloty";
            }

            if (con4.Text == "Thunderstorms")
            {
                con4.Text = "Burze";
            }

            if (con4.Text == "Drizzle")
            {
                con4.Text = "Mrzawka";
            }

            if (con4.Text == "Partly Cloudy")
            {
                con4.Text = "Pochmurno";
            }

            //Con5

            if (con5.Text == "Breezy")
            {
                con5.Text = "Rzeźko";
            }

            if (con5.Text == "Sunny")
            {
                con5.Text = "Słonecznie";
            }

            if (con5.Text == "Windy")
            {
                con5.Text = "Wietrznie";
            }

            if (con5.Text == "Showers")
            {
                con5.Text = "Opady";
            }

            if (con5.Text == "Rain")
            {
                con5.Text = "Deszcz";
            }

            if (con5.Text == "Mostly Cloudy")
            {
                con5.Text = "Zachmurzenie";
            }

            if (con5.Text == "Scattered Showers")
            {
                con5.Text = "Przeloty";
            }

            if (con5.Text == "Thunderstorms")
            {
                con5.Text = "Burze";
            }

            if (con5.Text == "Drizzle")
            {
                con5.Text = "Mrzawka";
            }

            if (con5.Text == "Partly Cloudy")
            {
                con5.Text = "Pochmurno";
            }
        }
        public void CorrectPic()
        {
            if (con1.Text == "Wietrznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\breezy.png");
                pic1.Image = Image.FromFile(filePath);
            }
            if (con1.Text == "Słonecznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\sunny.png");
                pic1.Image = Image.FromFile(filePath);
            }
            if (con1.Text == "Rzeźko")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\windy.png");
                pic1.Image = Image.FromFile(filePath);
            }
            if (con1.Text == "Opady")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\rain.png");
                pic1.Image = Image.FromFile(filePath);
            }
            if (con1.Text == "Zachmurzenie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\cloudy.png");
                pic1.Image = Image.FromFile(filePath);
            }
            if (con1.Text == "Deszcz")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\heavy rain.png");
                pic1.Image = Image.FromFile(filePath);
            }
            if (con1.Text == "Przeloty")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\light rain.png");
                pic1.Image = Image.FromFile(filePath);
            }

            //con2
            if (con2.Text == "Wietrznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\breezy.png");
                pic2.Image = Image.FromFile(filePath);
            }
            if (con2.Text == "Słonecznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\sunny.png");
                pic2.Image = Image.FromFile(filePath);
            }
            if (con2.Text == "Rzeźko")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\windy.png");
                pic2.Image = Image.FromFile(filePath);
            }
            if (con2.Text == "Opady")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\rain.png");
                pic2.Image = Image.FromFile(filePath);
            }
            if (con2.Text == "Zachmurzenie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\cloudy.png");
                pic2.Image = Image.FromFile(filePath);
            }
            if (con2.Text == "Deszcz")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\heavy rain.png");
                pic2.Image = Image.FromFile(filePath);
            }
            if (con2.Text == "Przeloty")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\light rain.png");
                pic2.Image = Image.FromFile(filePath);
            }

            //con3
            if (con3.Text == "Wietrznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\breezy.png");
                pic3.Image = Image.FromFile(filePath);
            }
            if (con3.Text == "Słonecznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\sunny.png");
                pic3.Image = Image.FromFile(filePath);
            }
            if (con3.Text == "Rzeźko")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\windy.png");
                pic3.Image = Image.FromFile(filePath);
            }
            if (con3.Text == "Opady")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\rain.png");
                pic3.Image = Image.FromFile(filePath);
            }
            if (con3.Text == "Zachmurzenie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\cloudy.png");
                pic3.Image = Image.FromFile(filePath);
            }
            if (con3.Text == "Deszcz")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\heavy rain.png");
                pic3.Image = Image.FromFile(filePath);
            }
            if (con3.Text == "Przeloty")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\light rain.png");
                pic3.Image = Image.FromFile(filePath);
            }

            //con4
            if (con4.Text == "Wietrznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\breezy.png");
                pic4.Image = Image.FromFile(filePath);
            }
            if (con4.Text == "Słonecznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\sunny.png");
                pic4.Image = Image.FromFile(filePath);
            }
            if (con4.Text == "Rzeźko")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\windy.png");
                pic4.Image = Image.FromFile(filePath);
            }
            if (con4.Text == "Opady")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\rain.png");
                pic4.Image = Image.FromFile(filePath);
            }
            if (con4.Text == "Zachmurzenie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\cloudy.png");
                pic4.Image = Image.FromFile(filePath);
            }
            if (con4.Text == "Deszcz")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\heavy rain.png");
                pic4.Image = Image.FromFile(filePath);
            }
            if (con4.Text == "Przeloty")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\light rain.png");
                pic4.Image = Image.FromFile(filePath);
            }

            //con5

            if (con5.Text == "Wietrznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\breezy.png");
                pic5.Image = Image.FromFile(filePath);
            }
            if (con5.Text == "Słonecznie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\sunny.png");
                pic5.Image = Image.FromFile(filePath);
            }
            if (con5.Text == "Rzeźko")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\windy.png");
                pic5.Image = Image.FromFile(filePath);
            }
            if (con5.Text == "Opady")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\rain.png");
                pic5.Image = Image.FromFile(filePath);
            }
            if (con5.Text == "Zachmurzenie")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\cloudy.png");
                pic5.Image = Image.FromFile(filePath);
            }
            if (con5.Text == "Deszcz")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\heavy rain.png");
                pic5.Image = Image.FromFile(filePath);
            }
            if (con5.Text == "Przeloty")
            {
                string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filePath = Path.Combine(directory, "Pack\\light rain.png");
                pic5.Image = Image.FromFile(filePath);
            }
        }

    }
}
