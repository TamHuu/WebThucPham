using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebThucPham.Models;

namespace WebThucPham.App_Start
{
    public class QuyenNhanVien : AuthorizeAttribute
    {
        // AuthorizeAttribute hàm có sẵn
        // AuthorizationContext đối tượng dữ liệu liên quan đến request
        // filterContext.Result Kết quả của request

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "DangNhap",
                    area = "Admin",
                }
                    ));

                return;
            }
            var user = (TaiKhoan)HttpContext.Current.Session["User"];
            string username = user.Username;
            string codeCN = this.Roles;
            KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();

            var demPhanQuyen = db.PhanQuyenChucNangs.Count(item =>

            item.CodeChucNang == codeCN
            & item.Username == username
            );

            if (demPhanQuyen == 0)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "KhongDuocPhanQuyen",
                    area = "Admin",
                }));
            }
            return;
        }

    }
}