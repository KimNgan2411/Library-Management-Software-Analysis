using QLTV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTV.Controllers
{
    public class MuonSachController : Controller
    {
        qltvEntities db = new qltvEntities();
        // Các phương thức cho thanh toán
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                MuonSach muonSach = Session["MuonSach"] as MuonSach;
                muonSach.ClearCart();
                return RedirectToAction("CheckOut_Success", "MuonSach");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin"); ;
            }
        }
        // 
        public PartialViewResult BagCart()
        {
            int total_quantity_item = 0;
            MuonSach muonSach = Session["MuonSach"] as MuonSach;
            if (muonSach != null)
            {
                total_quantity_item = muonSach.Total_quantity();
            }
            ViewBag.QuantityCart = total_quantity_item;
            return PartialView("BagCart");
        }
        // Thông báo thanh toán thành công
        public ActionResult CheckOut_Success()
        {
            return View();
        }
        // GET: ShoppingCart, chuẩn bị dữ liệu cho View
        public ActionResult ShowCart()
        {
            if (Session["MuonSach"] == null)
                return View("ShowCart");
            MuonSach _muonsach = Session["MuonSach"] as MuonSach;
            return View(_muonsach);
        }
        // Tạo mới giỏ hàng, nguồn được lấy từ Session
        public MuonSach GetCart()
        {
            MuonSach muonSach = Session["MuonSach"] as MuonSach;
            if (muonSach == null || Session["MuonSach"] == null)
            {
                muonSach = new MuonSach();
                Session["MuonSach"] = muonSach;
            }
            return muonSach;
        }
        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int id)
        {
            // lấy sản phẩm theo id
            var _pro = db.TuaSaches.SingleOrDefault(s => s.ma_tuasach == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "MuonSach");
        }
        // Cập nhật số lượng và tính lại tổng tiền
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            MuonSach muonSach = Session["MuonSach"] as MuonSach;
            int id_pro = int.Parse(Request.Form["idPro"]);
            int _quantity = int.Parse(Request.Form["carQuantity"]);
            muonSach.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "MuonSach");
        }
        // Xóa dòng sản phẩm trong giỏ hàng
        public ActionResult RemoveCart(int id)
        {
            MuonSach muonSach = Session["MuonSach"] as MuonSach;
            muonSach.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "MuonSach");
        }
    }
}