using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.Factories;

namespace ChristmasBlueBalls.Areas.CMS.Controllers
{
    public class HomeController : Controller
    {
        FacUsers objUsers = new FacUsers();

        FileLogger objLogger = new FileLogger();
        SecureCrypt objCrypt = new SecureCrypt();

        private const int Customer = 1;
        private const int Personel = 2;
        private const int Boss = 3;
        private const int Admin = 4;

        //------------------- CMS HOME CONTROLLER -------------------


        [HttpGet]
        public ActionResult Index()
        {
            if(((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from /CMS/Home/Index");

                return Redirect("/Login/Index");
            }

            if(((Users)Session["User"]).ID < Personel)
            {
                objLogger.LogError("[WARN] Unauthorized access to /CMS/Home/Index denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }
            

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("User");
            return Redirect("/Home/Index");
        }
    }
}