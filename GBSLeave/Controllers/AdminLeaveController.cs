using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GBSLeave.App_Code;
namespace GBSLeave.Controllers
{
    public class AdminLeaveController : Controller
    {
        // GET: AdminLeave
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult approvedList()
        {
            return View();
        }
        public ActionResult registerUser()
        {
            return View();
        }
        public ActionResult getDepartment()
        {
            string Id = Request.QueryString["BranchID"].ToString();
            int ID = Convert.ToInt32(Id);
            ViewBag.BranchID = ID;
            return View();
        }
        public ActionResult getEmployee()
        {
            string Id = Request.QueryString["DepartmentID"].ToString();
            string BranchId = Request.QueryString["BranchID"].ToString();
            int BranchID = Convert.ToInt32(BranchId);
            int ID = Convert.ToInt32(Id);
            ViewBag.DepartmentID = ID;
            ViewBag.BranchID = BranchID;
            return View();
        }

        public ActionResult getFromGetEmployee()
        {
            int EmpID = Convert.ToInt32(Request.Form["EmpID"]);
            string Username= Request.Form["Username"];
            string Password = Request.Form["Password"];
            AdminInsert a = new AdminInsert();
            a.insertUP(EmpID, Username, Password);
            string url = Session["url"].ToString();
            Response.Redirect(url);
            return View();
        }
        public ActionResult cancelRequest()
        {
            int EmpID = Convert.ToInt32(Request.QueryString["EmpID"]);
            int LeaveID = Convert.ToInt32(Request.QueryString["LeaveID"]);
            AdminInsert a = new AdminInsert();
            a.DeleteByQuery("delete from Used_Leave where LeaveID="+LeaveID+" and EmpID="+EmpID);
            a.DeleteByQuery("delete from Leave where ID=" + LeaveID);
            Response.Redirect("/leaveApply/getAdminPendingList");
            return View();
        }

        public ActionResult approveRequest()
        {
            int EmpID = Convert.ToInt32(Request.QueryString["EmpID"]);
            int LeaveID = Convert.ToInt32(Request.QueryString["LeaveID"]);
            AdminInsert a = new AdminInsert();
            a.UpdateByQuery("update Used_Leave set Status='approve' where EmpID=" + EmpID + " and LeaveID=" + LeaveID);
            Response.Redirect("/leaveApply/getAdminPendingList");
            return View();
        }
    }
}