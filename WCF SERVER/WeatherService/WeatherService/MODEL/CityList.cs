using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.MODEL
{
    public class CityList
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public CityList()
        {
                
        }
        public CityList(string _id, string _name)
        {
            ID = _id;Name = _name;
        }
    }
}
