using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;

namespace MVC.Services
{
    public class DBService<T> : IEditData
    {
        public enum Req
        {
            Put,
            Post
        }

        string connStr = ConfigurationManager.ConnectionStrings["SQLConn"].ConnectionString;


        public List<Object> GetSingleData(string table, string primeryKey, int id)
        {
            List<Object> ListO = new List<object>();

            string q = "SELECT * FROM "
            + table
            + " WHERE "
            + primeryKey
            + "="
            + id
            + "";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(q, con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int cou = reader.FieldCount;
                            for (int i = 0; i < cou; i++)
                            {
                                var item = reader.GetValue(i);
                                ListO.Add(item);
                            }

                            var idx = reader.GetInt32(0);
                            var name = reader.GetString(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }

            return ListO;
        }
        public List<T> GetData(string table)
        {
            List<T> Ts = new List<T>();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + table, con);
                con.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                var serializeObject = JsonConvert.SerializeObject(dataTable);
                Ts = JsonConvert.DeserializeObject<List<T>>(serializeObject);
            }

            return Ts;
        }

        internal void Delete(string table, string primeryKey, int carId)
        {
            string q = "DELETE FROM "
                + table
                + " WHERE "
                + primeryKey
                + "='"
                + carId
                + "'";

            ExecuteQuery(q);

        }


        public void Put(string table, string primeryKey, int carId)
        {

            string q = "DELETE FROM "
                + table
                + " WHERE "
                + primeryKey
                + "='"
                + carId
                + "'";

            ExecuteQuery(q);

        }

        public void PostData(string table, T obj, Req req)
        {
            Update(table, obj, req);
        }


        public void ExecuteQuery(string q)
        {
            using (var connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (var cmd = new SqlCommand(q, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(string table, T obj, Req req)
        {


            MappingService<T> mappingService = new MappingService<T>();

            using (var connection = new SqlConnection(connStr))
            {
                connection.Open();
                string keys = "";
                string AtKeys = "";
                string queryStr = "";
                foreach (var item in mappingService.MapObject(obj))
                {
                    keys += item.Key + ",";
                    AtKeys += "@" + item.Key + ",";
                }


                switch (req)
                {
                    case Req.Post:
                        queryStr = "INSERT INTO " + table
                                 + "("
                                 + keys.TrimEnd(',')
                                 + ") VALUES("
                                 + AtKeys.TrimEnd(',')
                                 + ")";

                        break;

                    case Req.Put:
                        queryStr = "INSERT INTO " + table
                                + "("
                                + keys.TrimEnd(',')
                                + ") VALUES("
                                + AtKeys.TrimEnd(',')
                                + ")";

                        break;
                }


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