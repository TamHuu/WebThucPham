using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        public ActionResult DanhSachSanPham(int? namsx, double? donGiaLonHon, double? donGiaNhoHon, string tenSanPham)
        {
            ViewBag.namsx = namsx;

            // Lấy toàn bộ dữ liệu
            KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
            var danhSach = db.SanPhams.ToList();

            // Tìm kiếm
            var kqTimKiem = db.SanPhams.Where(item =>
            (namsx == null || item.NamSanXuat == namsx)
            &&
            (donGiaLonHon == null || item.DonGia >= donGiaLonHon)
            &&
            (donGiaNhoHon == null || item.DonGia <= donGiaNhoHon)
            &&
            (string.IsNullOrEmpty(tenSanPham) == true || item.TenSanPham.ToLower().Contains(tenSanPham.ToLower()) == true)
            ).ToList();


            // Dùng store proc
            var kq2 = db.spSanPham(namsx, donGiaLonHon, donGiaNhoHon, tenSanPham).ToList();
            return View(kqTimKiem);
        }
        #region Thêm mới:
        public ActionResult ThemMoi()
        {
            SanPham spMoi = new SanPham();
            spMoi.NamSanXuat = DateTime.Now.Year;
            spMoi.DonGia = 0;
            spMoi.ThoiGianTao = DateTime.Now;
            spMoi.PhanLoai = "Loại 2";
            spMoi.HetHang = true;
            return View(spMoi);
        }
        [HttpPost]
        public ActionResult ThemMoi(SanPham spMoi)
        {
            // Bước 1: Check dữ liệu bắt buộc
            if (string.IsNullOrEmpty(spMoi.TenSanPham) && string.IsNullOrEmpty(spMoi.MoTa) == true)
            {
                ModelState.AddModelError("TenSanPham", "Thiếu tên sản phẩm");
                ModelState.AddModelError("MoTa", "Thiếu mô tả");
                ModelState.AddModelError("NamSanXuat", "Thiếu năm sản xuất");
                return View();
            }
            // Bước 2: Khai báo đối  tượng và gán giá trị
            //SanPham spMoi = new SanPham();
            //spMoi.TenSanPham = TenSanPham; 
            //spMoi.MoTa = MoTa;  
            //spMoi.DonGia = DonGia;
            //spMoi.NamSanXuat = NamSanXuat;  
            // Bước 3: Mở kết nối database
            KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
            // Bước 4: Thêm đối tượng mới vào mảng
            db.SanPhams.Add(spMoi);
            // Bước 5: Lưu lại dữ liệu
            db.SaveChanges();

            // Các loại chuyển hướng
            // 1. Chuyển về view cùng controller
            return RedirectToAction("DanhSachSanPham");
            // 2. Return về link cụ thể
            // 3. Link theo router
        }

        #endregion

        #region Cập nhật
        //2. Tạo form cập nhật
        public ActionResult CapNhat(string id)
        {
            try
            {
                var coverId = int.Parse(id);
                //2.1 Tìm đối tượng muốn cập nhật
                KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
                var sanPham = db.SanPhams.Find(coverId);
                return View(sanPham);
            }
            catch
            {
                return View(new SanPham());
            }

            //2.2 Gửi sang model view


        }
        //3. Hàm lưu cập nhật
        [HttpPost]
        public ActionResult CapNhat(SanPham model)
        {
            //3.1 Tìm đối tượng cần cập nhật
            KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
            var sanPham = db.SanPhams.Find(model.ID);
            //3.2 Gán gái trị nhận được từ model sang đối tượng cần cập nhật
            sanPham.DonGia = model.DonGia;
            sanPham.HetHang = model.HetHang;
            sanPham.MauSac = model.MauSac;
            sanPham.MoTa = model.MoTa;
            sanPham.NamSanXuat = model.NamSanXuat;
            sanPham.PhanLoai = model.PhanLoai;
            sanPham.TenSanPham = model.TenSanPham;
            sanPham.SoDienThoaiNCC = model.SoDienThoaiNCC;
            sanPham.EmailNCC = model.EmailNCC;
            //3.3. Lưu lại thay đổi
            db.SaveChanges();
            //3.4 Chuyển hướng về danh sách
            return RedirectToAction("DanhSachSanPham");
        }
        #endregion
        public ActionResult Xoa(int id)
        {
            //1. Tìm đối tượng cần xoá
            KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
            var sanPham = db.SanPhams.Find(id);
            //2.Xoá 
            db.SanPhams.Remove(sanPham);  
            //3. Cập nhật sự thay đổi
            db.SaveChanges();
            //4.Chuyển sang trang danh sách sản phẩm
            return RedirectToAction("DanhSachSanPham");
        }
    }


  

}