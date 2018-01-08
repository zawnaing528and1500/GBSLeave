using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace GBSLeave.App_Code
{
    public class RequestList
    {
        public DataTable GetPendingLeave(int EmpID)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Leave_Request.ID,Leave_Request.FromDate,Leave_Request.ToDate,Leave_Request.RequireDays,Leave_Request.LeaveReason,Leave_Request.MgrRemark FROM dbo.Leave_Request INNER JOIN dbo.Used_Leave ON Leave_Request.ID = Used_Leave.LeaveRequestID WHERE Used_Leave.EmpID= " + EmpID + " AND Used_Leave.Status= 'pending' ORDER BY Leave_Request.RequestDate DESC"))
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

        public DataTable GetApprovedLeave(int EmpID)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Leave_Request.ID, Leave_Request.FromDate,Leave_Request.ToDate,Leave_Request.RequireDays,Leave_Request.LeaveReason,Leave_Request.MgrRemark FROM dbo.Leave_Request INNER JOIN dbo.Used_Leave ON Leave_Request.ID = Used_Leave.LeaveRequestID WHERE Used_Leave.EmpID= " + EmpID + " AND Used_Leave.Status= 'approve' ORDER BY Leave_Request.RequestDate DESC"))
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