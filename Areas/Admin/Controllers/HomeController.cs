using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = (TaiKhoan)Session["User"];
            return View();
        }
        // GET: Admin/Home
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string username, string password)
        {
            // Kiểm tra thông tin tài khoản
            var user = new mapTaiKhoan().ChiTiet(username);

            // Kiểm tra tài khoản có tồn tại không
            if (user?.Username == null)
            {
                ViewBag.error = "Vui lòng nhập tên tài khoản hoặc tài khoản không tồn tại.";
                return View();
            }

            // Kiểm tra mật khẩu
            string formatPass = user.Password?.Trim();
            if (string.IsNullOrEmpty(formatPass))
            {
                ViewBag.error = "Vui lòng nhập mật khẩu.";
                return View();
            }

            if (formatPass != password)
            {
                ViewBag.error = "Mật khẩu không đúng.";
                return View();
            }

            // Đăng nhập thành công

            // Xử lý khi mà tài khoản đúng
            // 1. Lưu lại session
            Session["User"] = user;
            return RedirectToAction("Index");
        }

        public ActionResult DangXuat()
        {
            //1. Xoá session
            Session["User"] = null;
            return RedirectToAction("DangNhap");
        }


        public ActionResult KhongDuocPhanQuyen() 
        {
            return View();
        }
    }
}