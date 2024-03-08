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
    public class CuonSachesController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: CuonSaches
        public ActionResult Index()
        {
            var cuonSaches = db.CuonSaches.Include(c => c.DauSach).Include(c => c.Muon);
            return View(cuonSaches.ToList());
        }

        // GET: CuonSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuonSach cuonSach = db.CuonSaches.Find(id);
            if (cuonSach == null)
            {
                return HttpNotFound();
            }
            return View(cuonSach);
        }

        // GET: CuonSaches/Create
        public ActionResult Create()
        {
            ViewBag.isbn = new SelectList(db.DauSaches, "isbn", "ngonngu");
            ViewBag.isbn = new SelectList(db.Muons, "isbn", "isbn");
            return View();
        }

        // POST: CuonSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "isbn,Ma_CuonSach,TinhTrang")] CuonSach cuonSach)
        {
            if (ModelState.IsValid)
            {
                db.CuonSaches.Add(cuonSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.isbn = new SelectList(db.DauSaches, "isbn", "ngonngu", cuonSach.isbn);
            ViewBag.isbn = new SelectList(db.Muons, "isbn", "isbn", cuonSach.isbn);
            return View(cuonSach);
        }

        // GET: CuonSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuonSach cuonSach = db.CuonSaches.Find(id);
            if (cuonSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.isbn = new SelectList(db.DauSaches, "isbn", "ngonngu", cuonSach.isbn);
            ViewBag.isbn = new SelectList(db.Muons, "isbn", "isbn", cuonSach.isbn);
            return View(cuonSach);
        }

        // POST: CuonSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "isbn,Ma_CuonSach,TinhTrang")] CuonSach cuonSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuonSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isbn = new SelectList(db.DauSaches, "isbn", "ngonngu", cuonSach.isbn);
            ViewBag.isbn = new SelectList(db.Muons, "isbn", "isbn", cuonSach.isbn);
            return View(cuonSach);
        }

        // GET: CuonSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuonSach cuonSach = db.CuonSaches.Find(id);
            if (cuonSach == null)
            {
                return HttpNotFound();
            }
            return View(cuonSach);
        }

        // POST: CuonSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuonSach cuonSach = db.CuonSaches.Find(id);
            db.CuonSaches.Remove(cuonSach);
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
