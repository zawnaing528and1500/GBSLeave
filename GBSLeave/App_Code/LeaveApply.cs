using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GBSLeave.App_Code
{
    public class LeaveApply
    {
        public int getLeaveDay(int LeaveID)
        {
            int leaveDay = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT LeaveDay FROM dbo.Leave WHERE ID =" + LeaveID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        leaveDay = reader.GetInt32(0);
                    }
                }
            }
            return leaveDay;
        }

        public int getUsedLeave(int EmpID, int LeaveID)
        {
            int count = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Used_Leave WHERE LeaveID =" + LeaveID + " AND EmpID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count = count + 1;
                    }
                }
            }
            return count;
        }

        public DateTime getEmployDate(int EmpID)
        {
            DateTime date = new DateTime(1981, 03, 01);
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EmployDate FROM dbo.Employee WHERE ID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        date = reader.GetDateTime(0);
                    }
                }
            }
            return date;
        }

        public DateTime getApprovalDate(int EmpID)
        {
            DateTime date = new DateTime(1981, 03, 01);
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ApprovalDate FROM dbo.Employee WHERE ID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        date = reader.GetDateTime(0);
                    }
                }
            }
            return date;
        }



        public int getFingerID(int EmpID)
        {
            int fingerID = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT FingerID FROM dbo.Employee WHERE ID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        fingerID = reader.GetInt32(0);
                    }
                }
            }
            return fingerID;
        }



        public int getEmpID(int FingerID)
        {
            int ID = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ID FROM dbo.Employee WHERE FingerID=" + FingerID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                    }
                }
            }
            return ID;
        }


        public string getEmpName(int EmpID)
        {
            string name = "";
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EmpName FROM dbo.Employee WHERE ID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                    }
                }
            }
            return name;
        }


        public int getBranch(int EmpID)
        {
            int branch = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT BranchID FROM dbo.Employee WHERE ID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        branch = reader.GetInt32(0);
                    }
                }
            }
            return branch;
        }

        public int getLeaveID(string leaveName)
        {
            int LeaveID = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ID FROM dbo.Leave WHERE LeaveName='" + leaveName + "'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LeaveID = reader.GetInt32(0);
                    }
                }
            }
            return LeaveID;
        }


        public int getDept(int EmpID)
        {
            int dept = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT DeptID FROM dbo.Employee WHERE ID=" + EmpID, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dept = reader.GetInt32(0);
                    }
                }
            }
            return dept;
        }
        //
        public DataTable GetHandOverEmployee(int branch, int dept)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT EmpName FROM dbo.Employee WHERE BranchID=" + branch + "AND DeptID=" + dept))
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

        public int getFigerID(string EmpName)
        {
            int figerID = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT FingerID FROM dbo.Employee WHERE EmpName='" + EmpName + "'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        figerID = reader.GetInt32(0);
                    }
                }
            }
            return figerID;
        }

        public void InsertLeaveRequest(int EmpID, string LeaveReason, DateTime FromDate, DateTime ToDate, int RequireDays, Boolean isHalfDay, Boolean isCompassionate, int FingerID)
        {
            DateTime today = DateTime.Today;
            int ReplaceEmpID = getEmpID(FingerID);

            string query = "INSERT INTO dbo.Leave_Request(RequestDate,EmpID,LeaveReason,FromDate,ToDate,RequireDays,isHalfDay,isCompassionate,ReplaceEmpID) VALUES (@RequestDate,@EmpID,@LeaveReason,@FromDate,@ToDate,@RequireDays,@isHalfDay,@isCompassionate,@ReplaceEmpID)";
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RequestDate", today);
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.AddWithValue("@LeaveReason", LeaveReason);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.AddWithValue("@RequireDays", RequireDays);
                    cmd.Parameters.AddWithValue("@isHalfDay", isHalfDay);
                    cmd.Parameters.AddWithValue("@isCompassionate", isCompassionate);
                    cmd.Parameters.AddWithValue("@ReplaceEmpID", ReplaceEmpID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public void InsertLeaveRequestToUsedLeave(int EmpID, int LeaveID, DateTime FromDate, DateTime ToDate, decimal UsedLeave)
        {
            int LeaveRequestID = getLastInsertedLeaveRequestID();
            string query = "INSERT INTO dbo.Used_Leave(EmpID,LeaveID,FromDate,ToDate,LeaveRequestID,UsedLeave) VALUES (@EmpID,@LeaveID,@FromDate,@ToDate,@LeaveRequestID,@UsedLeave)";
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.AddWithValue("@LeaveID", LeaveID);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.AddWithValue("@LeaveRequestID", LeaveRequestID);
                    cmd.Parameters.AddWithValue("@UsedLeave", UsedLeave);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void UpdateLeaveRequest(int EmpID, int LeaveRequestID, string LeaveReason, DateTime FromDate, DateTime ToDate, int RequireDays, Boolean isHalfDay, Boolean isCompassionate)
        {
            DateTime today = DateTime.Today;
            //update where EmpID = 1 and LeaveID is...
            string query = "UPDATE dbo.Leave_Request SET LeaveReason=@LeaveReason,FromDate=@FromDate,ToDate=@ToDate,RequireDays=@RequiredDays,isHalfDay=@isHalfDay,isCompassionate=@isCompassionate WHERE ID = @LeaveRequestID AND EmpID = @EmpID";
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@LeaveReason", LeaveReason);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.AddWithValue("@RequireDays", RequireDays);
                    cmd.Parameters.AddWithValue("@isHalfDay", isHalfDay);
                    cmd.Parameters.AddWithValue("@isCompassionate", isCompassionate);
                    cmd.Parameters.AddWithValue("@LeaveRequestID", LeaveRequestID);
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void UpdateLeaveRequestToUsedLeave(int EmpID, int LeaveID, DateTime FromDate, DateTime ToDate, decimal UsedLeave)
        {
            int LeaveRequestID = getLastInsertedLeaveRequestID();
            string query = "UPDATE dbo.Used_Leave SET EmpID,LeaveID,FromDate,ToDate,LeaveRequestID,UsedLeave) VALUES (@EmpID,@LeaveID,@FromDate,@ToDate,@LeaveRequestID,@UsedLeave)";
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.AddWithValue("@LeaveID", LeaveID);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);
                    cmd.Parameters.AddWithValue("@LeaveRequestID", LeaveRequestID);
                    cmd.Parameters.AddWithValue("@UsedLeave", UsedLeave);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }



        public int getLastInsertedLeaveRequestID()
        {
            int LeaveRequestID = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM dbo.Leave_Request ORDER BY ID DESC", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LeaveRequestID = reader.GetInt32(0);
                    }
                }
            }
            return LeaveRequestID;
        }

        public void DeletePendingRequestFormUsedLeave(int EmpID, int ID)
        {
            string query = "DELETE FROM dbo.Used_Leave WHERE EmpID= @EmpID AND LeaveRequestID = @ID";
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void DeletePendingRequest(int EmpID, int ID)
        {
            string query = "DELETE FROM dbo.Leave_Request WHERE EmpID= @EmpID AND ID = @ID";
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", EmpID);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public DataTable GetStartDateAndEndDateOfRequest(int EmpID, int LeaveID)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT FromDate,ToDate FROM Used_Leave WHERE EmpID=" + EmpID + " AND LeaveID=" + LeaveID))
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


    }
}