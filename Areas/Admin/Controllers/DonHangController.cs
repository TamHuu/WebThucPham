using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult DanhSach(DateTime? ngay, int? idKhachHang, string thongTin)
        {
            ViewBag.ngay = ngay;
            ViewBag.idKhachHang = idKhachHang;
            ViewBag.thongTin = thongTin;

            // Tham số truyền từ view => action => hàm trong class map => hàm store sql
            return View(new mapDonHang().DanhSach(ngay, idKhachHang, thongTin));
        }

        public ActionResult ChiTiet(int idDonHang)
        {
            var donHang = new mapDonHang().ChiTiet(idDonHang);
            return View(donHang);
        }
    }
}