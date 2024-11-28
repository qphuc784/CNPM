using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class PhieuMuaHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }


        private int iDnhacungcap;
        public int IDNhaCungCap { get => iDnhacungcap; set => iDnhacungcap = value; }

        private int iDsanpham;
        public int IDSanPham { get => iDsanpham; set => iDsanpham = value; }

        private DateTime ngaymua;
        public DateTime NgayMua { get => ngaymua; set => ngaymua = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        private float dongia;
        public float DonGia { get => dongia; set => dongia = value; }

        public PhieuMuaHang(int iD, int iDnhacugcap, int iDsanpham, DateTime ngaymua, int soluong, float dongia)
        {
            this.ID = iD;
            this.IDNhaCungCap = iDnhacugcap;
            this.IDSanPham = iDsanpham;
            this.NgayMua = ngaymua;
            this.SoLuong = soluong;
            this.DonGia = dongia;
        }
    }
}
