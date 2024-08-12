using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebThucPham.Models
{
    public class SanPham
    {
        public int ID { get; set; }
        public string TenSanPham { get; set; }

        public int NamSanXuat { get; set; }

        public double DonGia { get; set; }

        public string MoTa { get; set; }

        public List<SanPham> GetDanhSach()
        {
            List<SanPham> danhSach = new List<SanPham>();
            danhSach.Add(new SanPham()
            {
                ID = 1,
                TenSanPham = " Fish Basa",
                NamSanXuat = 2024,
                DonGia = 1200000,
                MoTa = "Sell by Kg",
            });
            danhSach.Add(new SanPham()
            {
                ID = 2,
                TenSanPham = " Cow meal",
                NamSanXuat = 2022,
                DonGia = 2200000,
                MoTa = "Sell by Kg",
            });
            return danhSach;
        }
    }
}