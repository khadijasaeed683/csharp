using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UberNew
{
    internal class RiderCrud
    {
        public static bool StoreUserIntoDb(Rider user, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("Insert into Rider (Name, Email ,Password,Address, PhoneNumber) VALUES('{0}','{1}','{2}','{3}','{4}')", user.getName(), user.getEmail(), user.getPassword(), user.getAddress(),user.getPhoneNumber());
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Rider SignIn(Rider user, string connectionString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string us = user.getName();
                string pa = user.getPassword();
                string searchQuery = String.Format("Select * from Rider where Name = '{0}' and Password = '{1}'", us, pa);
                SqlCommand command = new SqlCommand(searchQuery, connection);
                SqlDataReader data = command.ExecuteReader();
                if (data.Read())
                {
                    Rider storedUser = new Rider(data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4));
                    connection.Close();
                    return storedUser;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            return null;
        }
    }
}
