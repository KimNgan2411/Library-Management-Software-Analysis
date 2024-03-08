using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTV.Models;
using PagedList;
using PagedList.Mvc;

namespace QLTV.Controllers
{
    public class TuaSachesController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: TuaSaches
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNum = (page ?? 1);
            IQueryable<TuaSach> tuaSaches = (from ma_tuasach in db.TuaSaches
                                             select ma_tuasach)
                                             .OrderBy(p => p.ma_tuasach);
            return View(tuaSaches.ToPagedList(pageNum,pageSize));
        }

        // GET: TuaSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuaSach tuaSach = db.TuaSaches.Find(id);
            if (tuaSach == null)
            {
                return HttpNotFound();
            }
            return View(tuaSach);
        }

        // GET: TuaSaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TuaSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_tuasach,TuaSach1,tacgia,tomtat")] TuaSach tuaSach)
        {
            if (ModelState.IsValid)
            {
                db.TuaSaches.Add(tuaSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuaSach);
        }

        // GET: TuaSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuaSach tuaSach = db.TuaSaches.Find(id);
            if (tuaSach == null)
            {
                return HttpNotFound();
            }
            return View(tuaSach);
        }

        // POST: TuaSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_tuasach,TuaSach1,tacgia,tomtat")] TuaSach tuaSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuaSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuaSach);
        }

        // GET: TuaSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuaSach tuaSach = db.TuaSaches.Find(id);
            if (tuaSach == null)
            {
                return HttpNotFound();
            }
            return View(tuaSach);
        }

        // POST: TuaSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuaSach tuaSach = db.TuaSaches.Find(id);
            db.TuaSaches.Remove(tuaSach);
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
