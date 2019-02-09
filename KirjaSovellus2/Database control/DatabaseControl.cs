using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirjaSovellus2.Database_control
{
    public class DatabaseControl
    {
        string connectionString = "Server=localhost;Database=kirjat;UID=root;password=''";

        public void InsertLainausToDb(string kirja, string kirjailija, string pvm)
        {
            try
            {

                string query = "INSERT INTO data(kirja_nimi, kirjailija_nimi, lainauspvm)" +
                        "VALUES('" + kirja + "','" + kirjailija + "','" + pvm + "')";

                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                while(reader.Read())
                {

                }
                connection.Close();

            } catch(Exception e)
            {
                Console.WriteLine(e.Message + "Virhe");
            }
        }

        public void InsertOstoToDb()
        {

        }
    }
}
