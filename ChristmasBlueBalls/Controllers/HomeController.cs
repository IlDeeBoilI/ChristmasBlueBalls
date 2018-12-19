using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.Factories;

namespace ChristmasBlueBalls.Controllers
{
    public class HomeController : Controller
    {


        //------------------- HOME CONTROLLER -------------------

        FacUsers objUsers = new FacUsers();
        FacProducts objProducts = new FacProducts();
        FacTypes objTypes = new FacTypes();

        SecureCrypt objCrypt = new SecureCrypt();


        [HttpGet]
        public ActionResult Index()
        {
            return View(objProducts.GetAll());
        }

        [HttpGet]
        public ActionResult Product(int ID = 0)
        {
            if(ID == 0)
            {
                return Redirect("/Home/Index");
            }

            return View(objProducts.Get(ID));
        }



        [ChildActionOnly]
        public ActionResult Types()
        {
            return PartialView("_TypeList", objTypes.GetAll());
        }
    }
}