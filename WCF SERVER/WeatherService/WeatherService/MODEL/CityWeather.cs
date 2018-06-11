using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.MODEL
{
    public class CityWeather
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime Date { get; set; }
        public string Temperature { get; set; }
        public CityWeather() { }
        public CityWeather(string _id, string _date, string _temp)
        {
            ID = _id;
            Date = DateTime.Parse(_date);
            Temperature = _temp;
        }
    }
}
