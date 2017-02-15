using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DbSlider.Models;
using System.IO;

namespace DbSlider.Controllers
{
    public class DbImgaesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DbImgaes
        public ActionResult Index()
        {
            return View(db.DbImgaes.ToList());
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                string[] file_name = fileName.Split('.');
                file.SaveAs(path);
                ApplicationDbContext db = new ApplicationDbContext();
                DbImgaes objDbImages = new DbImgaes();
                objDbImages.ImageName = file_name[0].ToString();
                objDbImages.ImagePath = "Content/Images/" + fileName;
                objDbImages.Status = true;
                db.DbImgaes.Add(objDbImages);

                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadUpdate(HttpPostedFileBase file,int id)
        {
            int a = id;
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                string[] file_name = fileName.Split('.');
                file.SaveAs(path);
                ApplicationDbContext db = new ApplicationDbContext();
                DbImgaes objDbImages = db.DbImgaes.Find(a);
                objDbImages.ImageName = file_name[0].ToString();
                objDbImages.ImagePath = "Content/Images/" + fileName;
                objDbImages.Status = true;
                
                db.SaveChanges();


            }
            return RedirectToAction("Index");
        }

        // GET: DbImgaes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbImgaes dbImgaes = db.DbImgaes.Find(id);
            if (dbImgaes == null)
            {
                return HttpNotFound();
            }
            return View(dbImgaes);
        }

        // GET: DbImgaes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbImgaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ImageName,ImagePath,Status")] DbImgaes dbImgaes)
        {
            if (ModelState.IsValid)
            {
                db.DbImgaes.Add(dbImgaes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbImgaes);
        }

        // GET: DbImgaes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbImgaes dbImgaes = db.DbImgaes.Find(id);
            if (dbImgaes == null)
            {
                return HttpNotFound();
            }
            return View(dbImgaes);
        }

        // POST: DbImgaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ImageName,ImagePath,Status")] DbImgaes dbImgaes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbImgaes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbImgaes);
        }

        // GET: DbImgaes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbImgaes dbImgaes = db.DbImgaes.Find(id);
            if (dbImgaes == null)
            {
                return HttpNotFound();
            }
            return View(dbImgaes);
        }

        // POST: DbImgaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DbImgaes dbImgaes = db.DbImgaes.Find(id);
            db.DbImgaes.Remove(dbImgaes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
