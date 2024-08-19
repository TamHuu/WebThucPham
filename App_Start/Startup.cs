using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebThucPham.App_Start.Startup))]

namespace WebThucPham.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Bật cors chia sẻ tài nguyên gốc chéo để thực hiện yêu cầu bằng trình duyêth từ các miền khác nhau
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //Tạo đường dẫn url lấy token
                TokenEndpointPath = new PathString("/token"),
                //Đặt thời gian hết hạn
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
                // Khai báo class sẽ sử dụng để xác thựcc thông tin người dùng
                Provider = new CheckUserLogin()
            };
            // Tạo token

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config= new HttpConfiguration();
            WebApiConfig.Register(config);

        }
    }
}
