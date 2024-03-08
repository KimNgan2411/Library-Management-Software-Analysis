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
    public class QuanLiesController : Controller
    {
        private qltvEntities db = new qltvEntities();

        // GET: QuanLies
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap(QuanLy _quanly)
        {
            var check = db.QuanLies.Where(s => s.taikhoan == _quanly.taikhoan && s.matkhau == _quanly.matkhau).FirstOrDefault();
            if (check == null)
            {
                ViewBag.LoiDangNhap = "Sai tài khoản hoặc mật khẩu";
                return View("Index");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["taikhoan"] = _quanly.taikhoan;
                Session["matkhau"] = _quanly.matkhau;
                return RedirectToAction("QuanLy", "Home");
            }
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]

        public ActionResult DangKy(QuanLy _quanly)
        {
            if (ModelState.IsValid)
            {
                var check_taikhoan = db.QuanLies.Where(s => s.taikhoan == _quanly.taikhoan).FirstOrDefault();
                if (check_taikhoan == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.QuanLies.Add(_quanly);
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
