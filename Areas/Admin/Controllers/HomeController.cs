using System;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Kiểm tra nếu người dùng đã đăng nhập
            var user = (TaiKhoan)Session["User"];
            if (user == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View();
        }

        // GET: Admin/Home/DangNhap
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
            if (string.IsNullOrEmpty(password) || user.Password?.Trim() != password)
            {
                ViewBag.error = "Mật khẩu không đúng.";
                return View();
            }

            // Đăng nhập thành công
            Session["User"] = user;
            return RedirectToAction("Index");
        }

        public ActionResult DangXuat()
        {
            // Xóa session khi đăng xuất
            Session["User"] = null;
            return RedirectToAction("DangNhap");
        }

        public ActionResult KhongDuocPhanQuyen()
        {
            return View();
        }

        /// <summary>
        /// Đăng nhập bằng JavaScript (AJAX)
        /// </summary>
        /// <param name="username">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Kết quả JSON</returns>
        [HttpPost]
        public JsonResult DangNhapJS(string username, string password)
        {
            // Kiểm tra tài khoản có tồn tại hay không
            var user = new mapTaiKhoan().ChiTiet(username);
            if (user == null)
            {
                return Json(new
                {
                    ketqua = false,
                    thongbao = "Tài khoản không hợp lệ."
                });
            }

            // Kiểm tra mật khẩu có hợp lệ hay không
            if (string.IsNullOrEmpty(user.Password) || user.Password.Trim() != password)
            {
                return Json(new
                {
                    ketqua = false,
                    thongbao = "Mật khẩu không chính xác."
                });
            }

            // Lưu lại session khi đăng nhập thành công
            Session["User"] = user;

            return Json(new
            {
                ketqua = true,
                thongbao = "Đăng nhập thành công."
            });
        }
    }
}
