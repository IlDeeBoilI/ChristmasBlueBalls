using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.Factories;
using System.IO;
using ChristmasBlueBalls.Helpers;

namespace ChristmasBlueBalls.Areas.CMS.Controllers
{
    public class ProductController : Controller
    {

        FacProducts objProducts = new FacProducts();

        FileLogger objLogger = new FileLogger();
        ImageTools objIT = new ImageTools();

        private const int Customer = 1;
        private const int Personel = 2;
        private const int Boss = 3;
        private const int Admin = 4;


        // GET: CMS/Product
        public ActionResult CreateProduct()
        {
            if (((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from [Get]/CMS/Product/CreateProduct");

                return Redirect("/Login/Index");
            }

            if (((Users)Session["User"]).ID < Personel)
            {
                objLogger.LogError("[WARN] Unauthorized access to [Get]/CMS/Product/CreateProduct denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Products input, HttpPostedFileBase picUpload)
        {
            if (((Users)Session["User"]) == null)
            {
                objLogger.LogError("[WARN] Unknown user excluded from [Post]/CMS/Product/CreateProduct");

                return Redirect("/Login/Index");
            }

            if (((Users)Session["User"]).ID < Personel)
            {
                objLogger.LogError("[WARN] Unauthorized access to [Post]/CMS/Product/CreateProduct denied - USER = " + ((Users)Session["User"]).Username + ", Email: " + ((Users)Session["User"]).Email);

                return Redirect("/Home/Index");
            }

            input.UserID = ((Users)Session["User"]).ID;
            
            if (picUpload != null)
            {
                string filePath = Request.PhysicalApplicationPath + "images\\Products\\";

                //string imagePath = Path.GetFileName(filePath);

                input.Image = objIT.SaveImage(picUpload, filePath);
            }

            objProducts.Insert(input);

            return View();
        }

    }
}