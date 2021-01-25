using System;
using System.Net;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Text;
using System.Windows.Controls;

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
            tempFeelLike.Text = weather.current.feelslike_c.ToString();
            description.Text = weather.current.condition.text;

            TextBlock textBlockTime = new TextBlock();
            TextBlock textBlockIcon = new TextBlock();
            TextBlock textBlockTemp = new TextBlock();

            string strTime = "";
            string strIcon = "";
            string strTemp = "";

            for (int i = 0; i < 24; i++)
            {
                strTime += weather.forecast.forecastday[0].hour[i].time.Substring(11) + "       ";
                strIcon += weather.forecast.forecastday[0].hour[i].icon + "       ";
                strTemp += weather.forecast.forecastday[0].hour[i].temp_c + "       ";
            }

            textBlockTime.Text = strTime;
            textBlockIcon.Text = strIcon;
            textBlockTemp.Text = strTemp;

            Grid.SetColumn(textBlockTime, 0);
            Grid.SetRow(textBlockTime, 0);

            Grid.SetColumn(textBlockIcon, 0);
            Grid.SetRow(textBlockIcon, 1);

            Grid.SetColumn(textBlockTemp, 0);
            Grid.SetRow(textBlockTemp, 2);

            temperatureGrid.Children.Add(textBlockTime);
            temperatureGrid.Children.Add(textBlockTemp);
            temperatureGrid.Children.Add(textBlockIcon);
        }
    }
}
