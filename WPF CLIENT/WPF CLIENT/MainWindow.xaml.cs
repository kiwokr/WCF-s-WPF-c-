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
            var client = new WeatherService.WeatherServiceClient("BasicHttpBinding_IWeatherService");
            string id = CBtest.SelectedValue.ToString();
            var temp = client.GetWeather(id);
            int l = temp.Length;
            //WeatherService.CityWeather weather = new WeatherService.CityWeather(temp.Date, temp.Temperature);


        }
        private void Refresh(object sender, RoutedEventArgs e)
        {

        }
    }
}
