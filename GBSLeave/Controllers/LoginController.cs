using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GBSLeave.App_Code;

namespace GBSLeave.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult checkUsernameAndPassword()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            LoginAuthorization l = new LoginAuthorization();
            if (l.checkUser(username, password))
            {
                int EmpID = l.getEmpID();
                Session["EmpID"] = EmpID;
                //Actually, it is needed to redirect to pending/approved leave request
                Response.Redirect("/LeaveApply/ApplicationForm");
            }
            return View();
        }
    }
}