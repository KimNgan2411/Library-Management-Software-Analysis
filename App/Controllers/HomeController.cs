using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLTV.Models;

namespace QLTV.Controllers
{
    public class HomeController : Controller
    {
        private qltvEntities db = new qltvEntities();

        public ActionResult Index()
        {
            return View(db.TuaSaches.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search(string SearchString)
        {
            var products = db.TuaSaches.Include(p => p.DauSaches);
            //Tìm kiếm chuỗi truy vấn theo TuaSach1, nếu chuỗi truy vấn SearchString khác rỗng, null
            if (!String.IsNullOrEmpty(SearchString))
            {

                products = products.Where(s => s.TuaSach1.Contains(SearchString));
            }
            return View(products.ToList());
        }
        public ActionResult QuanLy()
        {
            return View();
        }
    }
}