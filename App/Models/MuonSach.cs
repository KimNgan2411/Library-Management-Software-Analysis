using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTV.Models
{
    public class MuonSachItem
    {
        public TuaSach _product { get; set; }
        public int _quantity { get; set; }
    }
    public class MuonSach
    {
        // Dùng List để lưu trữ giỏ hàng → là một bảng tạm
        List<MuonSachItem> items = new List<MuonSachItem>();
        public IEnumerable<MuonSachItem> Items
        {
            get { return items; }
        }
        // Phương thức lấy sản phẩm bỏ vào giỏ hàng
        public void Add_Product_Cart(TuaSach _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ma_tuasach == _pro.ma_tuasach);
            if (item == null)
                items.Add(new MuonSachItem { _product = _pro, _quantity = _quan });
            else
                item._quantity += _quan;
        }
        // Phương thức tính tổng số lượng trong giỏ hàng
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        
        // Phương thức cập nhật số lượng khi khách hàng chọn SP mua thêm
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._product.ma_tuasach == id);
            if (item != null)
                item._quantity = _new_quan;
        }
        // Phương thức xóa sản phẩm trong giỏ hàng
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ma_tuasach == id);
        }
        // Phương thức xóa giỏ hàng (sau khi khách hàng thanh toán xong đơn hàng)
        public void ClearCart()
        {
            items.Clear();
        }
    }
}