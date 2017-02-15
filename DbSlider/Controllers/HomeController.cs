using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DbSlider.Models;

namespace DbSlider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Images(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                
                file.SaveAs(path);
                ApplicationDbContext db = new ApplicationDbContext();
                DbImgaes objDbImages = new DbImgaes();
                objDbImages.ImageName  =fileName.ToString();
                objDbImages.ImagePath = "Content/Images/" + fileName;
                objDbImages.Status = true;
                db.DbImgaes.Add(objDbImages);
                
                db.SaveChanges();
               


            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}