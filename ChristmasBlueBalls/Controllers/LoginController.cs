using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.Factories;

namespace ChristmasBlueBalls.Controllers
{
    public class LoginController : Controller
    {

        FacLogin objLogin = new FacLogin();
        SecureCrypt objCrypt = new SecureCrypt();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            if(Username.Length > 0 && Password.Length > 0)
            {
                Users user = objLogin.Login(Username.Trim());

                if(user.ID != 0)
                {
                    if(objCrypt.VerifyPassword(Password.Trim(), user.Password))
                    {
                        Session["User"] = user;
                        return Redirect("/CMS/Home/Index");
                    }
                    else
                    {
                        ViewBag.Error = "Username og password is incorrect";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "Username og password is incorrect";
                    return View();
                }
            }

            ViewBag.Error = "You must input a username and password";
            return View();
        }
    }
}