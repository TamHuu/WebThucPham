using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class mapPhanQuyenChucNang
    {
        KH2024_WebBanHangEntities db = new KH2024_WebBanHangEntities();
        public List<spQuyenTaiKhoan_Result> QuyenTaiKhoan(string username)
        {
            return db.spQuyenTaiKhoan(username).ToList();
        }

        public void LuuPhanQuyen(string username, string chucnang, bool? check)
        {
            if (check == true)
            {
                var phanQuyen = db.PhanQuyenChucNangs.SingleOrDefault(m => m.Username == username && m.CodeChucNang == chucnang);
                if (phanQuyen == null)
                {
                    phanQuyen = new PhanQuyenChucNang();
                    phanQuyen.Username = username;
                    phanQuyen.CodeChucNang = chucnang;
                    phanQuyen.GhiChu = "";
                    db.PhanQuyenChucNangs.Add(phanQuyen);
                    db.SaveChanges();
                }
            }
            else if (check == false)
            {
                var phanQuyen = db.PhanQuyenChucNangs.SingleOrDefault(m => m.Username == username && m.CodeChucNang == chucnang);
                if (phanQuyen != null)
                {
                    db.PhanQuyenChucNangs.Remove(phanQuyen);
                    db.SaveChanges();
                }
            }
        }

    }
}