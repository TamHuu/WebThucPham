using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebThucPham.App_Start;
using WebThucPham.Models;

namespace WebThucPham.Controllers
{
    [RoutePrefix("api/DataSanPham")]
    public class DataController : ApiController
    {
        // Cài thư viện 
        //  - System.Web.Http.WebHost
        //  - Microsoft.AspNet.WebApi.Core


        //1. Tạo controller kế thừa class ApiController => controller => Api
        //2. có 1 file route điều hướng api => WebApiConfig
        //3. Khai báo sử dụng route điều hướng api 

        // Các action
        //1. Get
        [HttpGet]
        [Route("GetList")]
        public IHttpActionResult DanhSach()
        {

            var map = new mapSanPham();
            var data = map.DanhSach();
            return Json(data.ToList());
        }
        //2. Post
        [HttpPost]
        [Route("ThemMoi")]
        public IHttpActionResult ThemMoi(SanPham model)
        {
            
            // Truyền tham số bình thường => sử dụng parameter
            // Truyền model  => Sử dụng body, x-www-form-urlencoded


            return Json(new
            {

            });
        }


        ///Token
        ///- Được cấp theo user và passworrd
        ///- Được mã hoá
        ///- Có thời hạn sử dụng
        /// jwt
        /// owin => source này dùng 
        /// install
        /// - Microsoft.Owin
        /// - Microsoft.Owin.Host.SystemWeb
        /// - Microsoft.Owin.Security
        /// - Microsoft.Owin.Security.OAuth


        [CheckToken(Roles = "User")]

        public IHttpActionResult Get()
        {
            return Json(new
            {
                result = true,
                status = "Bạn đã lấy thông tin"
            });
        }
    }
}
