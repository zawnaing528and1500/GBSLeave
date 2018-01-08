using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace GBSLeave.App_Code
{
    public class LeaveAdmin
    {
        public DataTable getAll(string tableName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from " + tableName, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable getAllByCondition(string tableName,string condition)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from " + tableName + condition, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public string getStringByCondition(string tableName, string colName, string condition)
        {
            string name = "Not Set";
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from " + tableName + condition, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                name = row[colName].ToString();
                            }
                        }
                    }
                }
            }
            return name;
        }

        public string getStringByCondition1(string tableName, string colName, string condition)
        {
            string name = "";
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from " + tableName + condition, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //name = reader.GetString("col");
                    }
                }
            }
            return name;
        }

        public int getIntByCondition(string tableName, string colName, string condition)
        {
            int name = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from " + tableName + condition, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                name = Convert.ToInt32(row[colName]);
                            }
                        }
                    }
                }
            }
            return name;
        }
        
        //Start Here
        public DataTable getAllByQuery(string query)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }


        public string getStringByQuery(string query, string Column)
        {
            string name = "";
            DataTable dt;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dt = new DataTable())
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                name = row[Column].ToString();
            }
            return name;
        }

        public int getIntByQuery(string query, string Column)
        {
            int name = 0;
            DataTable dt;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dt = new DataTable())
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                name = Convert.ToInt32(row[Column]);
            }
            return name;
        }

        //For total Number of a column
        public int getIntTotalByQuery(string query, string Column)
        {
            int name = 0;
            DataTable dt;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dt = new DataTable())
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                name = name + Convert.ToInt32(row[Column]);
            }
            return name;
        }

        public int getCountByQuery(string query)
        {
            int name = 0;
            DataTable dt;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dt = new DataTable())
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                name = name + 1;
            }
            return name;
        }


        public void DeleteByQuery(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


    }
}
