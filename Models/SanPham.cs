
namespace WebThucPham.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        public int ID { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> NamSanXuat { get; set; }
        public Nullable<double> DonGia { get; set; }
    }
}
