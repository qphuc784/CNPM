using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class PhieuBanHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int iDkhachhang;
        public int IDKhachHang { get => iDkhachhang; set => iDkhachhang = value; }

        private int idsanpham;
        public int IDSanPham { get => idsanpham; set => idsanpham = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        private int iDnhanvien;
        public int IDNhanVien { get => iDnhanvien; set => iDnhanvien = value; }

        private DateTime ngayban;
        public DateTime NgayBan { get => ngayban; set => ngayban = value; }


        public PhieuBanHang(int id, int idkhach, int idsp, int soluong, int iDnhanvien, DateTime ngayban)
        {
            this.ID = id;
            this.IDKhachHang = idkhach;
            this.IDSanPham = idsp;
            this.SoLuong = soluong;
            this.IDNhanVien = iDnhanvien;
            this.NgayBan = ngayban;
        }
    }
}
