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
         public KhachHang ChiTiet(int id)
        {
            return db.KhachHangs.Find(id);
        }

        public bool ThemMoi(KhachHang model)
        {
            //1. Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(model.TenKhachHang) == true)
            {
                return false;
            }  
                
            //2. Thêm vào bảng
            db.KhachHangs.Add(model);
            //3.Lưu database
            db.SaveChanges(); 
            return true;

        }

        public bool CapNhat(KhachHang model)
        {
            //1. Tìm đối tượng
            var updateModel = db.KhachHangs.Find(model.ID);
            if (updateModel == null) 
            {
                return false;
            }
            //2. Gán giá trị
            updateModel.TenKhachHang = model.TenKhachHang;
            updateModel.MaSoThue = model.MaSoThue;
            updateModel.DiaChi = model.DiaChi;  
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.NguoiDaiDien = model.NguoiDaiDien;  
            updateModel.ChucVu = model.ChucVu;
            updateModel.TenNganHang = model.TenNganHang;
            updateModel.TenVietTat = model.TenVietTat; 
            updateModel.SoDKKD = model.SoDKKD;  
            updateModel.SoDienThoaiNDD = model.SoDienThoaiNDD;
            updateModel.ChuTaiKhoan = model.ChuTaiKhoan;
            updateModel.TaiKhoanNganHang = model.TaiKhoanNganHang;
            //3. Lưu
            db.SaveChanges();
            return true;
        }

        public bool Xoa(int id)
        {
            //1. Tìm đối tượng
            var updateModel = db.KhachHangs.Find(id);
            if(updateModel == null)
            {
                return false;
            }   
            //2. Xoá
            db.KhachHangs.Remove(updateModel);
            //3.Lưu
            db.SaveChanges();
            return true;
        }
    }
}