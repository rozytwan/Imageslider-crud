using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DbSlider.Models;
namespace DbSlider.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            files = imageslist();
            return View("Index", files);
        }
        List<DbSlider.Models.DbImgaes> files;
        public void getImages()
        {

            string folderPath = Server.MapPath("~/assets/images/");
            string[] filePaths = Directory.GetFiles(folderPath);

            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new DbSlider.Models.DbImgaes
                {
                    ImageName = fileName.Split('.')[0].ToString(),
                    ImagePath = "../assets/images/" + fileName
                });
            }
        }

        public List<DbSlider.Models.DbImgaes> imageslist()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            files = db.DbImgaes.ToList();
            List<DbSlider.Models.DbImgaes> objimg = files.ToList();
            return objimg;
        }
    }
}