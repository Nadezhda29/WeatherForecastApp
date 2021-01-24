using System;
using System.Net;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Text;

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

            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Новосибирск&units=metric&lang=ru&appid=73b35156202c09452a570f755e69558d");
            request.Method = "POST";
            WebResponse response = request.GetResponse();

            InfoWeather infoWeather;
            string str = "";

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    str = reader.ReadToEnd();
                }
            }
            response.Close();

            infoWeather = JsonSerializer.Deserialize<InfoWeather>(str);

            selectedCity.Text = infoWeather.name;
            temperature.Text = infoWeather.main.temp.ToString();
            description.Text = infoWeather.weather[0].main;
            
        }
    }
}
