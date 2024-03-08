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
    public class NguoiLonsController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: NguoiLons
        public ActionResult Index()
        {
            var nguoiLons = db.NguoiLons.Include(n => n.DocGia);
            return View(nguoiLons.ToList());
        }

        // GET: NguoiLons/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiLon nguoiLon = db.NguoiLons.Find(id);
            if (nguoiLon == null)
            {
                return HttpNotFound();
            }
            return View(nguoiLon);
        }

        // GET: NguoiLons/Create
        public ActionResult Create()
        {
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho");
            return View();
        }

        // POST: NguoiLons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_docgia,sonha,duong,quan,dienthoai,han_sd")] NguoiLon nguoiLon)
        {
            if (ModelState.IsValid)
            {
                db.NguoiLons.Add(nguoiLon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", nguoiLon.ma_docgia);
            return View(nguoiLon);
        }

        // GET: NguoiLons/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiLon nguoiLon = db.NguoiLons.Find(id);
            if (nguoiLon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", nguoiLon.ma_docgia);
            return View(nguoiLon);
        }

        // POST: NguoiLons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_docgia,sonha,duong,quan,dienthoai,han_sd")] NguoiLon nguoiLon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiLon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", nguoiLon.ma_docgia);
            return View(nguoiLon);
        }

        // GET: NguoiLons/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiLon nguoiLon = db.NguoiLons.Find(id);
            if (nguoiLon == null)
            {
                return HttpNotFound();
            }
            return View(nguoiLon);
        }

        // POST: NguoiLons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            NguoiLon nguoiLon = db.NguoiLons.Find(id);
            db.NguoiLons.Remove(nguoiLon);
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
