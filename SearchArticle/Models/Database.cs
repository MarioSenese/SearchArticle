using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using DAL;
using System.Diagnostics;

using System.Web;
using System.Data;

using WebMatrix.Data;

namespace SearchArticle.Models
{
    public class Database
    {

        SqlConnection connection;

        public void Open()
        {

            ConnectionStringManager connectionStringManager = new ConnectionStringManager();
            var contrs = connectionStringManager.GetConnectionString();

            connection = new SqlConnection(contrs);

            try
            {

                connection.Open();
                Debug.Write("Connessione al server e database avvenuta con successo\n");
                Debug.WriteLine("State: {0}", connection.ServerVersion);
                Debug.WriteLine("State: {0}", connection.State);

            }
            catch (SqlException ex)
            {

                Debug.Write("Nessuna connessione al server e al database\n" + ex.ToString());

            }

        }

        //public Prodotto ExecuteQuerySQL() { }

        /*public List<string> ExecuteQuerySQL(string query)
        //public ViewModel ExecuteQuerySQL(string query)
        {

            var results = new List<string>();
            string result = "";

            using (SqlCommand command = new SqlCommand("", connection))
            {

                command.CommandText = query;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        
                        int totColumn = reader.FieldCount; // Numero totale di colonne
                        string columnName = "";
                        for (int i = 0; i < totColumn; i++)
                        {
                            columnName = reader.GetName(i);
                            //reader.Get

                            while (reader.Read())
                            {

                            

                            }

                        }

                    }
                    else
                    {
                        //Debug.Write("Non ci sono risultati");
                        results = null;
                    }

                }

                command.ExecuteNonQuery();


                //command.Parameters.AddWithValue();



            }

            return results;

        } */

        public void Close()
        {

            try
            {
                connection.Close();
                Debug.Write("\n Chiusura del database riuscita \n");
            } catch (SqlException ex) {
                Debug.Write("\n Chiusura del Database non riuscita \n" + ex.ToString());
            }

        }

        public Object Query(string querySQL)
        {

            Object results = null;
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = querySQL;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if(reader.HasRows)
                    {

                        int column = reader.FieldCount;

                        for(int i = 0; i < column; i++)
                        {

                            var count = 1;
                            while(reader.Read())
                            {

                                count++;
                            }

                        }


                    } else
                    {
                        Debug.Write("Non ci sono i risultati");
                    }

                }


            }

            return results;


        }


    }
}
