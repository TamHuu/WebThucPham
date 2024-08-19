using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security;
using WebThucPham.Models;

namespace WebThucPham.App_Start
{
    public class CheckUserLogin : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Client validation can be handled here if needed
            context.Validated(); // Mark the client authentication as successful
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Tài khoản trống => báo lỗi
            if (string.IsNullOrEmpty(context.UserName) == true)
            {
                context.SetError("Lỗi đăng nhập", "Tài khoản hoặc mật khẩu không đúng");
                return;
            }
            //Xác định user
            var user = new mapTaiKhoan().ChiTiet(context.UserName);
            if (user == null)
            {
                context.SetError("Lỗi đăng nhập", "Tài khoản không tồn tại!");
                return;
            }

            //Check mật khẩu
            if (user.Password.Trim() != context.Password)
            {
                context.SetError("Lỗi đăng nhập", "Mật khẩu không đúng");
                return;
            }
            // Xử lý trường hợp đăng nhập đúng
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name,context.UserName));
            context.Validated(identity);
        }
    }
}
