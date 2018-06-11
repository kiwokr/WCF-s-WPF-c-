using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.DATAMAPPER
{
    class MySQLMapper
    {
        /// <summary>
        /// Set values in City table
        /// </summary>
        /// <returns></returns>
        public static void SetData(string _id, string _name, string _url)
        {
            string connectString = "Database=gismeteo;Data Source=localhost;User Id=root;Password=qxx7wm4ufe;SSLMode=none;charset=utf8";
            using (MySqlConnection sqlConnect = new MySqlConnection(connectString))
            {

                sqlConnect.Open();
                MySqlCommand sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = @"INSERT INTO City(ID,Name,URL) VALUES(@ID,@Name,@URL) ON DUPLICATE KEY UPDATE Name = @Name, URL = @URL";
                sqlCommand.Parameters.Add("@ID", MySqlDbType.VarChar);
                sqlCommand.Parameters["@ID"].Value = _id;
                sqlCommand.Parameters.Add("@Name", MySqlDbType.VarChar);
                sqlCommand.Parameters["@Name"].Value = _name;
                sqlCommand.Parameters.Add("@URL", MySqlDbType.VarChar);
                sqlCommand.Parameters["@URL"].Value = _url;
                sqlCommand.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Set values in weather table
        /// </summary>
        /// <returns></returns>
        public static void SetData(string _id, DateTime _dateTime, string _temp)
        {
            string connectString = "Database=gismeteo;Data Source=localhost;User Id=root;Password=qxx7wm4ufe;SSLMode=none;charset=utf8";
            using (MySqlConnection sqlConnect = new MySqlConnection(connectString))
            {
                sqlConnect.Open();
                MySqlCommand sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = @"INSERT INTO weather(CityID,DateTime,Temperature) VALUES(@CityID,@DateTime,@Temperature) ON DUPLICATE KEY UPDATE DateTime = @DateTime, Temperature = @Temperature";
                sqlCommand.Parameters.Add("@CityID", MySqlDbType.VarChar);
                sqlCommand.Parameters["@CityID"].Value = _id;
                sqlCommand.Parameters.Add("@DateTime", MySqlDbType.DateTime);
                sqlCommand.Parameters["@DateTime"].Value = _dateTime;
                sqlCommand.Parameters.Add("@Temperature", MySqlDbType.VarChar);
                sqlCommand.Parameters["@Temperature"].Value = _temp;
                sqlCommand.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Gets weather in city by ID
        /// </summary>
        /// <returns></returns>
        public static MODEL.CityWeather GetData(string _id)
        {
            string connectString = "Database=gismeteo;Data Source=localhost;User Id=root;Password=qxx7wm4ufe;SSLMode=none";
            using (MySqlConnection sqlConnect = new MySqlConnection(connectString))
            {
                sqlConnect.Open();
                MySqlCommand sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = @"SELECT Cityid,DateTime,Temperature FROM weather WHERE CityID=@CityID";
                sqlCommand.Parameters.Add("@CityID", MySqlDbType.VarChar);
                sqlCommand.Parameters["@CityID"].Value = _id;
                MODEL.CityWeather requestResult = new MODEL.CityWeather();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    requestResult.ID = _id;
                    requestResult.Date = DateTime.Parse(reader[1].ToString());
                    requestResult.Temperature = reader[2].ToString();
                }
                return requestResult;
            }
        }
        /// <summary>
        /// Gets citys list
        /// </summary>
        /// <returns></returns>

        public static List<MODEL.CityList> GetData()
        {
            string connectString = "Database=gismeteo;Data Source=localhost;User Id=root;Password=qxx7wm4ufe;SSLMode=none";
            using (MySqlConnection sqlConnect = new MySqlConnection(connectString))
            {
                sqlConnect.Open();
                MySqlCommand sqlCommand = new MySqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = @"SELECT ID,Name FROM city";
                List<MODEL.CityList> requestResult = new List<MODEL.CityList>();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    requestResult.Add(new MODEL.CityList(reader[0].ToString(), reader[1].ToString()));
                }
                return requestResult;

            }
        }
    }
}
