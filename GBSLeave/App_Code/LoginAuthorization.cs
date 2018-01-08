using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace GBSLeave.App_Code
{
    public class LoginAuthorization
    {
        int EmpID;
        public Boolean checkUser(string username, string password)
        {
            Boolean isUser = false;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ID FROM dbo.PublicUser WHERE Username = '" + username + "' and Password = '" + password + "'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["ID"] != DBNull.Value)
                        {
                            EmpID = reader.GetInt32(0);
                            isUser = true;
                        }
                    }
                }
            }
            return isUser;
        }

        public int getEmpID()
        {
            return EmpID;
        }
    }
}