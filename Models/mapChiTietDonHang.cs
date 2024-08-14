using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class mapChiTietDonHang
    {
        KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();

        public List<ChiTietDonHang> DanhSach(int idDonHang)
        {
            var ChiTietDonHang = db.ChiTietDonHangs.Where(item=>item.ID == idDonHang).ToList();
            return ChiTietDonHang;
        }
    }
}