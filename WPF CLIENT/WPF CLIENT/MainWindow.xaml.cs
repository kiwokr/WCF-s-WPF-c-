using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CLIENT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var client = new WeatherService.WeatherServiceClient("BasicHttpBinding_IWeatherService");
            var temp = client.GetCities();
            List<WeatherService.CityList> cites = new List<WeatherService.CityList>();
            foreach (var item in temp)
            {
                cites.Add(new WeatherService.CityList(item.ID, item.Name));
            }
            CBtest.ItemsSource = cites;
            CBtest.DisplayMemberPath = "Name";
            CBtest.SelectedValuePath = "ID";
        }

        private void ShowWeather(object sender, RoutedEventArgs e)
        {
            if(CBtest.SelectedValue != null)
            {
                var client = new WeatherService.WeatherServiceClient("BasicHttpBinding_IWeatherService");
                string id = CBtest.SelectedValue.ToString();
                WeatherService.CityWeather weather = client.GetWeather(id);
                LableText.Text = "Погода на " + weather.Date.ToString("D") + " Последнее обновление " + weather.Date.AddDays(-1).ToString("f");
                string[] temp = weather.Temperature.Split(' ');
                Time.Text = " 0:00   3:00   6:00   9:00   12:00   15:00   18:00   21:00";
                Temp.Text = " " + temp[0] + "   " + temp[1] + "   " + temp[2] + "   " + temp[3] + "    " + temp[4] + "     " + temp[5] + "     " + temp[6] + "     " + temp[7];
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new WeatherService.WeatherServiceClient("BasicHttpBinding_IWeatherService");
            client.UploadData();
        }
    }
}
