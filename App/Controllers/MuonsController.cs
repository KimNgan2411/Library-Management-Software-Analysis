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
    public class MuonsController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: Muons
        public ActionResult Index()
        {
            var muons = db.Muons.Include(m => m.CuonSach).Include(m => m.DocGia);
            return View(muons.ToList());
        }

        // GET: Muons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muon muon = db.Muons.Find(id);
            if (muon == null)
            {
                return HttpNotFound();
            }
            return View(muon);
        }

        // GET: Muons/Create
        public ActionResult Create()
        {
            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang");
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho");
            return View();
        }

        // POST: Muons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "isbn,ma_cuonsach,ma_docgia,ngayGio_muon,ngay_hethan")] Muon muon)
        {
            if (ModelState.IsValid)
            {
                db.Muons.Add(muon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang", muon.isbn);
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", muon.ma_docgia);
            return View(muon);
        }

        // GET: Muons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muon muon = db.Muons.Find(id);
            if (muon == null)
            {
                return HttpNotFound();
            }
            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang", muon.isbn);
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", muon.ma_docgia);
            return View(muon);
        }

        // POST: Muons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "isbn,ma_cuonsach,ma_docgia,ngayGio_muon,ngay_hethan")] Muon muon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang", muon.isbn);
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", muon.ma_docgia);
            return View(muon);
        }

        // GET: Muons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muon muon = db.Muons.Find(id);
            if (muon == null)
            {
                return HttpNotFound();
            }
            return View(muon);
        }

        // POST: Muons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Muon muon = db.Muons.Find(id);
            db.Muons.Remove(muon);
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
