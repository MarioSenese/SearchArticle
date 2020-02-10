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

                string queryString = "SELECT TOP (10) * FROM eice.Accounts a;"; 
                SqlCommand command = new SqlCommand(queryString, connection);

                using(SqlDataReader reader = command.ExecuteReader()) // recupero di dati in base alla query sql definita
                {

                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Debug.Write(string.Format("{0}, {1}, {2}, {3}", reader[0], reader[2], reader[3], reader[13]) + "\n");
                        }

                    } else
                    {
                        Debug.Write("Non ci sono risultati");
                    }

                }


                connection.Close();

            }
            catch (SqlException ex)
            {
                Debug.Write("Nessuna connessione al server e al database\n" + ex.ToString());
            }

        }

        


    }
}
