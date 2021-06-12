using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BacExamProcess.DataAccess
{
    class SQLServerConnection
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["conString"].ToString();
        }
        public static string sqlString;
        public static SqlConnection connection = new SqlConnection();
        public static SqlCommand SqlCommand = new SqlCommand("", connection);
        public static SqlDataReader dataReader;
        public static DataTable dataTable;
        public static SqlDataAdapter dataAdapter;
        public static void openConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.ConnectionString = GetConnectionString();
                    connection.Open();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur de connexion à la base de données est survenue"
                    , "Veuillez contacter votre administrateur"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Error);
            }
        }
        public static void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur de connexion à la base de données est survenue"
                    , "Veuillez contacter votre administrateur"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Error);
            }
        }
    }
}
