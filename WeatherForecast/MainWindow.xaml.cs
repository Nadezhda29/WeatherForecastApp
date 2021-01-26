using System;
using System.Net;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WeatherForecast
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WebRequest request = WebRequest.Create("http://api.weatherapi.com/v1/forecast.json?key=48331233b3a143f094780957212401&q=Новосибирск&lang=ru");
            WebResponse response = request.GetResponse();

            Weather weather;
            string str = "";

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    str = reader.ReadToEnd();
                }
            }
            response.Close();

            weather = JsonSerializer.Deserialize<Weather>(str);

            selectedCity.Text = weather.location.name;
            temperature.Text = weather.current.temp_c.ToString();
            tempFeelLike.Text = "Ощущается " + weather.current.feelslike_c.ToString();
            description.Text = weather.current.condition.text;

            string strTime = "   ";
            string strTemp = "   ";
            Image[] icons = new Image [24];


            for (int i = 0; i < 24; i++)
            {
                strTime += weather.forecast.forecastday[0].hour[i].time.Substring(11) + "        ";
                strTemp += weather.forecast.forecastday[0].hour[i].temp_c + "        ";

                icons[i] = new Image();
                icons[i].Height = 51;
                icons[i].Width = 51;
                icons[i].Source = new BitmapImage(new Uri($"http:{weather.forecast.forecastday[0].hour[i].condition.icon}"));
            }

            foreach (Image icon in icons)
            {
                iconPanel.Children.Add(icon);
            }

            timeText.Text = strTime;
            temperatureText.Text = strTemp;
        }
    }
}
