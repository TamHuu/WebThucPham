using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class mapSanPham
    {
        KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();

        public List<SanPham> DanhSach()
        {
            return db.SanPhams.ToList();
        }

        public SanPham ChiTiet(int idDonHang)
        {
            return db.SanPhams.Find(idDonHang);
        }
    }
}