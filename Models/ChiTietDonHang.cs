//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebThucPham.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDonHang
    {
        public int ID { get; set; }
        public Nullable<int> idDonHang { get; set; }
        public Nullable<int> idSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<double> MucThueVAT { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public string DonViTinh { get; set; }
    
        public virtual DonHang DonHang { get; set; }
    }
}
