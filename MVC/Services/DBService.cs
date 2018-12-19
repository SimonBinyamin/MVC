using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;

namespace MVC.Services
{
    public class DBService<T>
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

        internal void Delete(string table, string primeryKey, int id)
        {
            string q = "DELETE FROM "
                + table
                + " WHERE "
                + primeryKey
                + "='"
                + id
                + "'";
            ExecuteQuery(q);
        }


        public void Put(string table, T obj, Req req)
        {
            Update(table, obj, req);
        }

        public void PostData(string table, T obj, Req req)
        {
            Update(table, obj, req);
        }

        public void Update(string table, T obj, Req req)
        {
            MappingService<T> mappingService = new MappingService<T>();
            using (var connection = new SqlConnection(connStr))
            {
                connection.Open();
                string queryStr = "";

                var keyList = from item in mappingService.MapObject(obj) select item.Key;
                var valueList = from item in mappingService.MapObject(obj) select item.Value;
                var atKeyList = from item in mappingService.MapObject(obj) select "@" + item.Key;


                string keys = String.Join(",", keyList);
                string atKeys = String.Join(",", atKeyList);

                switch (req)
                {
                    case Req.Post:
                        queryStr = "INSERT INTO " + table
                                 + "("
                                 + keys.TrimEnd(',')
                                 + ") VALUES("
                                 + atKeys.TrimEnd(',')
                                 + ")";
                        break;

                    case Req.Put:
                        string updatedStr = String.Join(",", (from b in mappingService.MapObject(obj) where b.Key!="Id" select b.Key + "=@" + b.Key));
                        queryStr = "UPDATE " + table
                                + " SET "
                                + updatedStr
                                + " WHERE Id='"
                                + valueList.ToList()[0]
                                + "'";
                        break;
                }

                using (var cmd = new SqlCommand(queryStr, connection))
                {
                    foreach (var item in mappingService.MapObject(obj))
                    {
                        if (item.Key!="Id")
                        {
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
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

    }
}