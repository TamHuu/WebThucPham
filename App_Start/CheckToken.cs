using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebThucPham.App_Start
{
    public class CheckToken : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Kiểm tra quyền truy cập của người dùng
            // Lấy thông tin user: Name => owin tự phân giải token để lấy thông tin
            var username = HttpContext.Current.User.Identity.Name;

            // Nếu người dùng không có quyền truy cập hoặc không đăng nhập
            if (string.IsNullOrEmpty(username))
            {
                // Tạo phản hồi lỗi với thông báo không có quyền truy cập
                var errorResponse = new { error = "Token không hợp lệ" };
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    errorResponse,
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                );

                // Kết thúc xử lý và không gọi base.OnAuthorization
                return;
            }

            // Gọi phương thức cơ sở để thực hiện kiểm tra quyền truy cập khác (nếu có)
            base.OnAuthorization(actionContext);
        }
    }
}
