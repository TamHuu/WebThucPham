using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class mapDonHang
    {
        KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();

        public  List<spDanhSachDonHang2_Result> DanhSach(DateTime? ngay, int? idKhachHang, string thongTin)
        {
            return db.spDanhSachDonHang2(ngay, idKhachHang,thongTin).ToList();
        }

        public DonHang ChiTiet(int idDonHang)
        {
            return db.DonHangs.Find(idDonHang);
        }
    }
}