using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Providers.Models;
using MySql.Data.MySqlClient;

namespace Providers
{
    public class ObjectHandler
    {
        private MySqlConnection conn;

        public ObjectHandler()
        {
            string connectionString = "SERVER=localhost; DATABASE=providers;UID=root;PASSWORD=password;";
            conn = new MySqlConnection(connectionString);
        }

        public DataTable RetrieveDBValues(string cmdString)
        {

            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(cmdString, conn);
                sda.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }


        public Provider ConvertToProvider(DataRow dr)
        {
            Provider provider = new Provider();
            provider.Id = (int)dr["Id"];
            provider.Name = dr["Name"].ToString();
            provider.Category= dr["Category"].ToString();
            provider.Price = (decimal)dr["Price"];
            return provider;
        }
    }
}