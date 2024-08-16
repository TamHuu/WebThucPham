using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class mapTaiKhoan
    {
        KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();

        public List<TaiKhoan> DanhSach()
        {
            return db.TaiKhoans.ToList();
        }

        public TaiKhoan ChiTiet(string name)
        {
            return db.TaiKhoans.Find(name);
        }
    }
}