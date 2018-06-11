using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WeatherService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWeatherService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        /// <summary>
        /// uploaded data from gismeteo.ru
        /// </summary>
        /// <returns></returns>
        void UploadData();


        [OperationContract]
        /// <summary>
        /// Return city list
        /// </summary>
        /// <returns></returns>
        List<MODEL.CityList> GetCities();


        [OperationContract]
        /// <summary>
        /// Return weather in city by id
        /// </summary>
        /// <returns></returns>
        MODEL.CityWeather GetWeather(string ID);
    }
}
