using System;
using System.Net;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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
        }

        public string InsertSpace(string str, int n)
        {
            for (int i = 0; i < n - str.Length; i++)
            {
                str += " ";
            }
            return str;
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            iconPanel.Children.Clear();
            timeText.Children.Clear();
            temperatureText.Children.Clear();

            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            WebRequest request = WebRequest.Create($"http://api.weatherapi.com/v1/forecast.json?key=48331233b3a143f094780957212401&q={selectedItem.Content}&lang=ru");
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

            Image[] icons = new Image[24];
            TextBox[] textTime = new TextBox[24];
            TextBox[] textTemp = new TextBox[24];

            for (int i = 0; i < 24; i++)
            {

                textTime[i] = new TextBox();
                textTime[i].Width = 50;
                textTime[i].Background = new SolidColorBrush(Colors.LightBlue);
                textTime[i].BorderBrush = new SolidColorBrush(Colors.LightBlue);
                textTime[i].Text = weather.forecast.forecastday[0].hour[i].time.Substring(11);
                textTime[i].HorizontalContentAlignment = HorizontalAlignment.Center;

                textTemp[i] = new TextBox();
                textTemp[i].Width = 50;
                textTemp[i].Background = new SolidColorBrush(Colors.LightBlue);
                textTemp[i].BorderBrush = new SolidColorBrush(Colors.LightBlue);
                textTemp[i].Text = weather.forecast.forecastday[0].hour[i].temp_c.ToString();
                textTemp[i].HorizontalContentAlignment = HorizontalAlignment.Center;

                icons[i] = new Image();
                icons[i].Height = 50;
                icons[i].Width = 50;
                icons[i].Source = new BitmapImage(new Uri($"http:{weather.forecast.forecastday[0].hour[i].condition.icon}"));
            }

            foreach (Image icon in icons)
            {
                iconPanel.Children.Add(icon);
            }

            foreach (TextBox textBox in textTime)
            {
                timeText.Children.Add(textBox);
            }

            foreach (TextBox textBox1 in textTemp)
            {
                temperatureText.Children.Add(textBox1);
            }

            //timeText.Text = strTime;
            //temperatureText.Text = strTemp;
        }
    }
}
