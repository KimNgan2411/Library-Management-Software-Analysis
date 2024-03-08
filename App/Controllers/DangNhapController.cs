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
    public class DangNhapController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap(DocGia _docgia)
        {
            var check = db.DocGias.Where(s => s.taikhoan == _docgia.taikhoan && s.matkhau == _docgia.matkhau).FirstOrDefault();
            if (check == null)
            {
                ViewBag.LoiDangNhap = "Sai tài khoản hoặc mật khẩu";
                return View("Index");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["taikhoan"] = _docgia.taikhoan;
                Session["matkhau"] = _docgia.matkhau;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]

        public ActionResult DangKy(DocGia _docgia)
        {
            if (ModelState.IsValid)
            {
                var check_taikhoan = db.DocGias.Where(s => s.taikhoan == _docgia.taikhoan).FirstOrDefault();
                if (check_taikhoan == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.DocGias.Add(_docgia);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.LoiDangKy = "Tài khoản đã có người sử dụng!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
