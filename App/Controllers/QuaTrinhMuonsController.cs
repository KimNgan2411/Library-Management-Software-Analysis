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
    public class QuaTrinhMuonsController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: QuaTrinhMuons
        public ActionResult Index()
        {
            var quaTrinhMuons = db.QuaTrinhMuons.Include(q => q.CuonSach).Include(q => q.DocGia);
            return View(quaTrinhMuons.ToList());
        }

        // GET: QuaTrinhMuons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuaTrinhMuon quaTrinhMuon = db.QuaTrinhMuons.Find(id);
            if (quaTrinhMuon == null)
            {
                return HttpNotFound();
            }
            return View(quaTrinhMuon);
        }

        // GET: QuaTrinhMuons/Create
        public ActionResult Create()
        {
            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang");
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho");
            return View();
        }

        // POST: QuaTrinhMuons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "isbn,ma_cuonsach,ngayGio_muon,ma_docgia,ngay_hethan,ngayGio_tra,tien_muon,tien_datra,tien_datcoc,ghichu")] QuaTrinhMuon quaTrinhMuon)
        {
            if (ModelState.IsValid)
            {
                db.QuaTrinhMuons.Add(quaTrinhMuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang", quaTrinhMuon.isbn);
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", quaTrinhMuon.ma_docgia);
            return View(quaTrinhMuon);
        }

        // GET: QuaTrinhMuons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuaTrinhMuon quaTrinhMuon = db.QuaTrinhMuons.Find(id);
            if (quaTrinhMuon == null)
            {
                return HttpNotFound();
            }
            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang", quaTrinhMuon.isbn);
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", quaTrinhMuon.ma_docgia);
            return View(quaTrinhMuon);
        }

        // POST: QuaTrinhMuons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "isbn,ma_cuonsach,ngayGio_muon,ma_docgia,ngay_hethan,ngayGio_tra,tien_muon,tien_datra,tien_datcoc,ghichu")] QuaTrinhMuon quaTrinhMuon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quaTrinhMuon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isbn = new SelectList(db.CuonSaches, "isbn", "TinhTrang", quaTrinhMuon.isbn);
            ViewBag.ma_docgia = new SelectList(db.DocGias, "ma_docgia", "ho", quaTrinhMuon.ma_docgia);
            return View(quaTrinhMuon);
        }

        // GET: QuaTrinhMuons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuaTrinhMuon quaTrinhMuon = db.QuaTrinhMuons.Find(id);
            if (quaTrinhMuon == null)
            {
                return HttpNotFound();
            }
            return View(quaTrinhMuon);
        }

        // POST: QuaTrinhMuons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuaTrinhMuon quaTrinhMuon = db.QuaTrinhMuons.Find(id);
            db.QuaTrinhMuons.Remove(quaTrinhMuon);
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
