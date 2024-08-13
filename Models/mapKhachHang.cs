using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class mapKhachHang
    {
        // HÀM: Danh sách => Trả về danh sách khách hàng => Lọc theo tên, số điện thoại, mã số thuế
        // Hàm thêm mới
        // Hàm chi tiết
        // Hàm cập nhật
        // Hàm xoá: 1 đối tượng

        KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
        public List<KhachHang> DanhSach(string thongtin)
        {
            thongtin = (thongtin ?? "").ToLower();
            return db.KhachHangs.Where(m=>m.TenKhachHang.ToLower().Contains(thongtin)
                                          || m.SoDienThoai.ToLower().Contains(thongtin)
                                          || m.MaSoThue.ToLower().Contains(thongtin)
            
            ).ToList();
        }
        public void ThemMoi(KhachHang model)
        {
            //1. Kiểm tra dữ liệu

            //2. Thêm vào bảng

            //3.Lưu database
        }
    }
}