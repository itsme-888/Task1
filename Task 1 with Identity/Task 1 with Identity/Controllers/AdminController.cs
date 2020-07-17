using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1_with_Identity.Models;

namespace Task_1_with_Identity.Controllers
{
    public class AdminController : Controller
    {
        Model1 db = new Model1();

        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db);
        }
    }
}