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

            MessageBox.Show(weather.forecast.forecastday[0].hours[0].time);

            //foreach (Hour element in weather.forecast)
            //{
            //    temperatureGrid.RowDefinitions[0].DataContext = element.time;
            //    temperatureGrid.RowDefinitions[1].DataContext = element.icon;
            //    temperatureGrid.RowDefinitions[2].DataContext = element.temp_c;
            //}
        }
    }
}
