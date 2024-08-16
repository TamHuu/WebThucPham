using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        public ActionResult DanhSach()
        {
            return View(new mapTaiKhoan().DanhSach());
        }

        public ActionResult ChiTiet(string username)
        {
            return View(new mapTaiKhoan().ChiTiet(username));

        }
        public ActionResult LuuPhanQuyen(string username, string chucnang, bool? check)
        {
            var map = new mapPhanQuyenChucNang();
            map.LuuPhanQuyen(username, chucnang, check ?? false); // Gán giá trị mặc định là false nếu check là null
            return RedirectToAction("ChiTiet", new { username = username });
        }



    }
}