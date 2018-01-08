using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GBSLeave.Controllers
{
    public class GBSHomeController : Controller
    {
        // GET: GBSHome
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}