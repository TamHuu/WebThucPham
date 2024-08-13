using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult DanhSach(string thongtin)
        {
            mapKhachHang map = new mapKhachHang();
            var dsKH = map.DanhSach(thongtin);
            return View(dsKH);
        }

        public ActionResult ThemMoi(int id) 
        {
            return View(new KhachHang());
        }
        [HttpPost]
        public ActionResult ThemMoi(KhachHang model)
        {
            mapKhachHang map = new mapKhachHang();
           if(map.ThemMoi(model)==true)
            {
                return RedirectToAction("DanhSach");
            }
           else
            {
                return View(model); 
            }    
        }

        public ActionResult CapNhat(int id)
        {
            mapKhachHang map = new mapKhachHang();
            var kh = map.ChiTiet(id);
            return View(kh);
        }

        [HttpPost]
        public ActionResult CapNhat(KhachHang model)
        {
            mapKhachHang map = new mapKhachHang();
            if (map.CapNhat(model) == true)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            mapKhachHang map = new mapKhachHang();
            map.Xoa(id);
            return RedirectToAction("DanhSach");
        }
    }
}