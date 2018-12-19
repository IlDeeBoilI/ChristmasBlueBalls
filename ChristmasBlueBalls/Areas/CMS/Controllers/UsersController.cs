using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.Factories;

namespace ChristmasBlueBalls.Areas.CMS.Controllers
{
    public class UsersController : Controller
    {

        FacUsers objUsers = new FacUsers();

        FileLogger objLogger = new FileLogger();
        SecureCrypt objCrypt = new SecureCrypt();

        private const int Customer = 1;
        private const int Personel = 2;
        private const int Boss = 3;
        private const int Admin = 4;

        [HttpGet]
        public ActionResult AddUser()
        {
            if (((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from [Get]/CMS/Users/AddUser");

                return Redirect("/Login/Index");
            }

            if (((Users)Session["User"]).ID < Boss)
            {
                objLogger.LogError("[WARN] Unauthorized access to [Get]/CMS/Users/Adduser denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddUser(Users input, string verifyPass)
        {
            if (((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from [Post]/CMS/Users/AddUser");

                return Redirect("/Login/Index");
            }

            if (((Users)Session["User"]).ID < Boss)
            {
                objLogger.LogError("[WARN] Unauthorized access to [Post]/CMS/Users/AddUser denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }

            if (input.Password == verifyPass)
            {
                input.Username = input.Username.Trim();
                input.Password = objCrypt.EncryptPassword(input.Password.Trim());

                objUsers.Insert(input);
                return View();
            }

            else
            {
                ViewBag.Error = "Kodeordene var ikke ens";
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            if (((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from [Get]/CMS/Users/GetUsers");

                return Redirect("/Login/Index");
            }

            if (((Users)Session["User"]).ID < Boss)
            {
                objLogger.LogError("[WARN] Unauthorized access to [Get]/CMS/Users/GetUsers denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }
            return View(objUsers.GetAllUsersRoles());
        }

        [HttpGet]
        public ActionResult GetUser(int ID = 0)
        {
            if (((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from [Post]/CMS/Users/GetUser");

                return Redirect("/Login/Index");
            }

            if (((Users)Session["User"]).ID < Boss)
            {
                objLogger.LogError("[WARN] Unauthorized access to [Post]/CMS/Users/GetUser denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }

            return View(objUsers.GetUserRole(ID));
        }
    }
}