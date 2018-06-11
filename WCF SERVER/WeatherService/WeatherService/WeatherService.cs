using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WeatherService.MODEL;

namespace WeatherService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WeatherService" в коде и файле конфигурации.
    public class WeatherService : IWeatherService
    {
        public List<CityList> GetCities()
        {
            return DATAMAPPER.MySQLMapper.GetData();
        }

        public CityWeather GetWeather(string ID)
        {
            return DATAMAPPER.MySQLMapper.GetData(ID);
        }

        public void UploadData()
        {
            string baseUrl = "https://www.gismeteo.ru";
            string prefix = "tomorrow/";
            Console.Title = "HOST";

            string DATA = PARSERS.AngleSharpParser.DownloadHTML(baseUrl);
            var doc = PARSERS.AngleSharpParser.ParserHTML(DATA, "noscript a");

            foreach (var T1 in doc)
            {
                string CityData = PARSERS.AngleSharpParser.DownloadHTML(baseUrl + T1.GetAttribute("href") + prefix);
                var Temp = PARSERS.AngleSharpParser.ParserHTML(CityData, "div", x => x.ClassName == "value" && x.HasAttribute("style"));
                int count = 0;
                int _i = 0;
                string tempValues = "";
                foreach (var T2 in Temp)
                {
                    if (count >= 6 && count < 14)
                    {
                        tempValues += T2.TextContent;
                        tempValues += ' ';
                        _i++;
                    }
                    count++;
                }

                DATAMAPPER.MySQLMapper.SetData(T1.GetAttribute("data-id"), T1.GetAttribute("data-name").ToString(), T1.GetAttribute("href"));
                DATAMAPPER.MySQLMapper.SetData(T1.GetAttribute("data-id"), DateTime.Now.AddDays(1), tempValues);
                tempValues = null;
            }
        }
    }
}
