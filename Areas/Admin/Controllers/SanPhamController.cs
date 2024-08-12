using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class SanPhamController:Controller
    {
        public ActionResult DanhSachSanPham(int? namsx, double? donGiaLonHon, double? donGiaNhoHon, string tenSanPham)
        {
            ViewBag.namsx = namsx;
            KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
            var danhSach = db.SanPhams.ToList();
            return View(danhSach);
        }
    }
}