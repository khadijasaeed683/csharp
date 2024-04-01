using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UberNew.DL
{
    internal class DriverCrud
    {
        public static bool StoreDriverInDb(Driver dr)
        {
            string con = Utility.ConnectionString();
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string query = String.Format("Insert into Drivers (DriverName, DriverIdCard, PhoneNumber, CarModel,License,JoiningDate) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", dr.getDriverName(), dr.getDriverIdCard(), dr.getPhoneNumber(), dr.getCarModel(), dr.getLicense(),dr.GetJoiningDate());
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
        public static Driver SignIn(Driver user, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string searchQuery = String.Format("Select * from Drivers where DriverName = '{0}' and DriverIdCard = '{1}'", user.getDriverName(), user.getDriverIdCard());
            SqlCommand command = new SqlCommand(searchQuery, connection);
            SqlDataReader data = command.ExecuteReader();
            if (data.Read())
            {

                Driver storedUser = new Driver(data.GetString(0), data.GetString(2), data.GetString(4), data.GetString(5), data.GetString(1));
                connection.Close();
                return storedUser;
            } 
            connection.Close();
            return null;
        }
    }
}
