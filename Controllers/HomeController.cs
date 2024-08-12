using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.XinChao = "Welcome to C#";
            TempData["How"] = "Làm bài nè";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HowItWork()
        {
            
            return View();
        }
        public ActionResult Explore()
        {
            var listSP = new List<SanPham>();
            for (int i = 1; i<=6; i++)
            {
                var sanPham1 = new SanPham();
                sanPham1.ID = i;
                sanPham1.TenSanPham = "Apple DaLas" + i;
                listSP.Add(sanPham1);
            }    

            return View(listSP);
        }
    }
}