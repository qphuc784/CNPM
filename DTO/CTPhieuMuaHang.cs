using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangDaQuy.DTO
{
    public class CTPhieuMuaHang
    {
        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int iDPhieuMuaHang;
        public int IDPhieuMuaHang { get => iDPhieuMuaHang; set => iDPhieuMuaHang = value; }

        private int iDnhacungcap;
        public int IDNhaCungCap { get => iDnhacungcap; set => iDnhacungcap = value; }

        private int iDsanpham;
        public int IDSanPham { get => iDsanpham; set => iDsanpham = value; }

        private int soluong;
        public int SoLuong { get => soluong; set => soluong = value; }

        private float dongia;
        public float DonGia { get => dongia; set => dongia = value; }

        public CTPhieuMuaHang(int iD, int iDPhieuMuaHang, int iDnhacugcap, int iDsanpham, int soluong, float dongia)
        {
            this.ID = iD;
            this.IDPhieuMuaHang = iDPhieuMuaHang;
            this.IDNhaCungCap = iDnhacugcap;
            this.IDSanPham = iDsanpham;
            this.SoLuong = soluong;
            this.DonGia = dongia;
        }

        public CTPhieuMuaHang(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDPhieuMuaHang = (int)row["IDPhieuNhapHang"];
            this.IDNhaCungCap = (int)row["IDNhaCungCap"];
            this.IDSanPham = (int)row["IDSanPham"];
            this.SoLuong = (int)row["SoLuong"];
            this.DonGia = Convert.ToSingle(row["DonGia"]);
        }
    }
}
