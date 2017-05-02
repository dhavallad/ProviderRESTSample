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
    public class ProviderHandler
    {
        private MySqlConnection conn;

        public bool returnValue;

        public ProviderHandler()
        {
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["providers"].ConnectionString);
            string connectionString = "SERVER=localhost; DATABASE=providers;UID=root;PASSWORD=;";
            conn = new MySqlConnection(connectionString);
        }


        public List<Provider> retrieveAllProviders()
        {
            ObjectHandler oh = new ObjectHandler();
            string cmdString = "Select * from provider";
            DataTable dt = oh.RetrieveDBValues(cmdString);
            List<Provider> providers = new List<Provider>();
            foreach (DataRow dr in dt.Rows)
            {
                providers.Add(oh.ConvertToProvider(dr));
            }
            return providers;

        }

        public Provider retrieveProivder(int id)
        {
            ObjectHandler oh = new ObjectHandler();
            string cmdString = string.Format("Select * from provider where Id={0}", id);
            DataTable dt = oh.RetrieveDBValues(cmdString);
            Provider providers = new Provider();

            foreach (DataRow dr in dt.Rows)
            {
                providers = oh.ConvertToProvider(dr);
            }
            return providers;
        }


    }
}