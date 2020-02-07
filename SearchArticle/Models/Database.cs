using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;
using DAL;
using System.Diagnostics;

namespace SearchArticle.Models
{
    public class Database
    {

        

        public void connectDB()
        {

            //string config = configuration["ConString1"];
            ConnectionStringManager connectionStringManager = new ConnectionStringManager();
            var contrs = connectionStringManager.GetConnectionString();


            Debug.Write("_configuration: " + contrs);

            SqlConnection connection = new SqlConnection(contrs);

            try
            {

                connection.Open();
                Debug.Write("Connessione al server e database avvenuta con successo\n");
                Debug.WriteLine("State: {0}", connection.ServerVersion);
                Debug.WriteLine("State: {0}", connection.State);

                connection.Close();


            }
            catch (SqlException ex)
            {
                Debug.Write("Nessuna connessione al server e al database\n" + ex.ToString());
            }

        }

    }
}
