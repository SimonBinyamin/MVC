using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Services
{
    public class DBService<T>
    {
        string connStr = ConfigurationManager.ConnectionStrings["SQLConn"].ConnectionString;
        public List<T> GetData (string table)
        {
            List<T> Ts = new List<T>();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM "+table, con);
                con.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                var serializeObject = JsonConvert.SerializeObject(dataTable);
                Ts = JsonConvert.DeserializeObject<List<T>>(serializeObject);
            }

            return Ts;
        }


        public void PostData (string table, T obj)
        {
            MappingService<T> mappingService = new MappingService<T>();
            
            using (var connection = new SqlConnection(connStr))
            {
                connection.Open();
                string keys = "";
                string AtKeys = "";

                foreach (var item in mappingService.MapObject(obj))
                {
                    keys += item.Key + ",";
                    AtKeys += "@" + item.Key + ",";
                }

                string queryStr = "INSERT INTO " + table 
                                                 + "(" 
                                                 + keys.TrimEnd(',') 
                                                 + ") VALUES(" 
                                                 + AtKeys.TrimEnd(',') 
                                                 + ")";

                using (var cmd = new SqlCommand(queryStr, connection))
                {
                    foreach (var item in mappingService.MapObject(obj))
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}