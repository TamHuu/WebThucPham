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
            return db.ChiTietDonHangs.Where(item => item.idDonHang == idDonHang).ToList();
        }

        public int ThemMoi(ChiTietDonHang model)
        {
            //1. Kiểm tra dữ liệu
            if (model.idDonHang == 0)
            {
                return 0;
            }
            if (model.idSanPham == 0)
            {
                return 0;
            }
            var sanPham = db.SanPhams.Find(model.idSanPham);

            if (sanPham != null)
            {
                model.TenSanPham = sanPham.TenSanPham;
            }
            if (model.DonGia == null)
            {
                model.DonGia = 0;
            }
            if (model.MucThueVAT == null)
            {
                model.MucThueVAT = 0;
            }
            if (model.SoLuong == null)
            {
                model.SoLuong = 0;
            }
            model.ThanhTien = (model.DonGia * model.SoLuong) * (model.DonGia * model.SoLuong) * model.MucThueVAT / 100;
            //2. Thêm vào bảng
            db.ChiTietDonHangs.Add(model);
            //3.Lưu database
            db.SaveChanges();
            return model.ID;

        }
    }
}