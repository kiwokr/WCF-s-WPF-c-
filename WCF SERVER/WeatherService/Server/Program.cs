using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var HOST = new ServiceHost(typeof(WeatherService.WeatherService)))
            {
                HOST.Open();
                Console.WriteLine("HOST ready");
                Console.ReadKey();
            }
        }
    }
}
