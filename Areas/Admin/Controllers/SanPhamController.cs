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
    }


}