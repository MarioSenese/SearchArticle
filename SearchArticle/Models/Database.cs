using System.Data.SqlClient;
using DAL;
using System.Diagnostics;
using System.Collections.Generic;

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



        public List<string> ExecuteQuerySQL(string query, string paramValue)
        //public ViewModel ExecuteQuerySQL(string query)
        {

            List<string> res = new List<string>();

            SqlCommand command = new SqlCommand(query, connection);
            if (paramValue != null)
            {
                command.Parameters.AddWithValue("@paramValue", paramValue);
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {

                        try
                        {

                            //res.Add((System.String)reader[i]);
                            int numCol = reader.FieldCount;
                            for (int j = 0; j < numCol; j++) {

                                res.Add(reader[j].ToString());


                            }

                        }
                        catch (System.InvalidCastException ex) { }

                        i++;

                    }
                }
                else
                {
                    res = null;
                }

            }

            return res;

        }
        /* var results = new List<string>();
            string result = "";

            using (SqlCommand command = new SqlCommand("", connection))
            {

                command.CommandText = query;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    int totColumns = reader.FieldCount; // Numero totale di colonne
                    Debug.Write("totColumns: " + totColumns);
                    string columnName = "";

                    if (reader.HasRows) {

                        int row = 0;
                        while (reader.Read()) {

                            for (int c = 0; c < totColumns; c++) {



                            }

                            row++;
                        }

                        Debug.Write("\ntotRows: " + row + "\n");

                    }


                }

                command.ExecuteNonQuery();


                //command.Parameters.AddWithValue();*/



        //}

    //} 

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

        
    }
}
