﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KH2024_WebBanHangEntities : DbContext
    {
        public KH2024_WebBanHangEntities()
            : base("name=KH2024_WebBanHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
    
        public virtual ObjectResult<spSanPham_Result> spSanPham(Nullable<int> namsx, Nullable<double> donGiaLonHon, Nullable<double> donGiaNhoHon, string tenSanPham)
        {
            var namsxParameter = namsx.HasValue ?
                new ObjectParameter("namsx", namsx) :
                new ObjectParameter("namsx", typeof(int));
    
            var donGiaLonHonParameter = donGiaLonHon.HasValue ?
                new ObjectParameter("donGiaLonHon", donGiaLonHon) :
                new ObjectParameter("donGiaLonHon", typeof(double));
    
            var donGiaNhoHonParameter = donGiaNhoHon.HasValue ?
                new ObjectParameter("donGiaNhoHon", donGiaNhoHon) :
                new ObjectParameter("donGiaNhoHon", typeof(double));
    
            var tenSanPhamParameter = tenSanPham != null ?
                new ObjectParameter("tenSanPham", tenSanPham) :
                new ObjectParameter("tenSanPham", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSanPham_Result>("spSanPham", namsxParameter, donGiaLonHonParameter, donGiaNhoHonParameter, tenSanPhamParameter);
        }
    
        public virtual ObjectResult<spDanhSachDonHang2_Result> spDanhSachDonHang2(Nullable<System.DateTime> ngay, Nullable<int> idKhachHang, string thongTin)
        {
            var ngayParameter = ngay.HasValue ?
                new ObjectParameter("ngay", ngay) :
                new ObjectParameter("ngay", typeof(System.DateTime));
    
            var idKhachHangParameter = idKhachHang.HasValue ?
                new ObjectParameter("idKhachHang", idKhachHang) :
                new ObjectParameter("idKhachHang", typeof(int));
    
            var thongTinParameter = thongTin != null ?
                new ObjectParameter("thongTin", thongTin) :
                new ObjectParameter("thongTin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spDanhSachDonHang2_Result>("spDanhSachDonHang2", ngayParameter, idKhachHangParameter, thongTinParameter);
        }
    }
}
