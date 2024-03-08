using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTV.Models;

namespace QLTV.Controllers
{
    public class DocGiasController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: DocGias
        public ActionResult Index()
        {
            var docGias = db.DocGias.Include(d => d.NguoiLon);
            return View(docGias.ToList());
        }

        // GET: DocGias/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // GET: DocGias/Create
        public ActionResult Create()
        {
            ViewBag.ma_docgia = new SelectList(db.NguoiLons, "ma_docgia", "sonha");
            return View();
        }

        // POST: DocGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_docgia,ho,tenlot,ten,NgaySinh")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.DocGias.Add(docGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_docgia = new SelectList(db.NguoiLons, "ma_docgia", "sonha", docGia.ma_docgia);
            return View(docGia);
        }

        // GET: DocGias/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_docgia = new SelectList(db.NguoiLons, "ma_docgia", "sonha", docGia.ma_docgia);
            return View(docGia);
        }

        // POST: DocGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_docgia,ho,tenlot,ten,NgaySinh")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_docgia = new SelectList(db.NguoiLons, "ma_docgia", "sonha", docGia.ma_docgia);
            return View(docGia);
        }

        // GET: DocGias/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            DocGia docGia = db.DocGias.Find(id);
            db.DocGias.Remove(docGia);
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
